using EMS.Domain.Models.Import;

namespace EMS.Domain.Common
{
    public static class ExcelImportHelper
    {
        public static List<ExcelImportResult<TDto>> ParseExcel<TDto>(byte[] fileBytes)
            where TDto : new()
        {
            var result = new List<ExcelImportResult<TDto>>();
            try
            {
                using (var stream = new MemoryStream(fileBytes))
                using (var workbook = new ClosedXML.Excel.XLWorkbook(stream))
                {
                    var ws = workbook.Worksheet(1);
                    var props = typeof(TDto).GetProperties();

                    int currentRow = 2;
                    foreach (var row in ws.RowsUsed().Skip(1))
                    {
                        var dto = new TDto();
                        string? parseError = null;
                        int col = 1;

                        foreach (var prop in props)
                        {
                            var cellValue = row.Cell(col).GetValue<string>();
                            if (!string.IsNullOrWhiteSpace(cellValue))
                            {
                                try
                                {
                                    var converted = Convert.ChangeType(
                                        cellValue,
                                        Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType
                                    );
                                    prop.SetValue(dto, converted);
                                }
                                catch (Exception)
                                {
                                    parseError = $"Không thể parse giá trị '{cellValue}' tại cột {col} -> {prop.Name}";
                                    break;
                                }
                            }
                            col++;
                        }

                        result.Add(new ExcelImportResult<TDto>
                        {
                            Data = dto,
                            RowNumber = currentRow,
                            ParseError = parseError
                        });
                        currentRow++;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Add(new ExcelImportResult<TDto>
                {
                    Data = new TDto(),
                    RowNumber = 0,
                    ParseError = $"Lỗi khi đọc file Excel: {ex.Message}"
                });
            }
            return result;
        }
    }

}
