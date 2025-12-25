namespace EMS.Domain.Models.Import
{
    public class ExcelImportResult<TDto>
    {
        public int RowNumber { get; set; }
        public string ParseError { get; set; }
        public TDto Data { get; set; }
    }
}
