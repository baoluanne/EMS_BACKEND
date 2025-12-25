namespace EMS.Application.Services.SinhVienServices.Dtos
{
    public class ImportHinhSinhVienResponseDto
    {
        public List<ImportHinhSinhVienResult> SuccessList { get; set; } = [];
        public List<ImportHinhSinhVienResult> FailedList { get; set; } = [];
        public int TotalChunks { get; set; }
        public int ChuckIndex { get; set; }
        public int TotalCount => SuccessList.Count + FailedList.Count;
        public int TotalSuccess => SuccessList.Count;
        public int TotalFailed => FailedList.Count;

        public ImportHinhSinhVienResponseDto(List<ImportHinhSinhVienResult> successList, List<ImportHinhSinhVienResult> failedList, int totalChunks, int chuckIndex)
        {

            SuccessList = successList;
            FailedList = failedList;
            TotalChunks = totalChunks;
            ChuckIndex = chuckIndex;
        }
    }

}
