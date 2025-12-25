namespace EMS.Domain.Models.Import
{
    public class ImportResultResponse<TDto>
    {
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
        public int TotalRecords { get; set; }
        public int SuccessRecords { get; set; }
        public int FailedRecords { get; set; }
        public List<ImportRowResponse<TDto>> Rows { get; set; } = new();
    }
    public class ImportRowResponse<TDto>
    {
        public int RowNumber { get; set; }
        public TDto Data { get; set; } = default!;
        public bool Success { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
