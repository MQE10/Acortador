using System;
using System.Collections.Generic;

namespace AcortadorApi.ModelsLog
{
    public partial class LogApiSaad
    {
        public long Id { get; set; }
        public string? Project { get; set; }
        public string Path { get; set; } = null!;
        public long? UserId { get; set; }
        public int? CampusId { get; set; }
        public string? IpsClient { get; set; }
        public string? QueryString { get; set; }
        public string Method { get; set; } = null!;
        public string? Payload { get; set; }
        public string Response { get; set; } = null!;
        public string ResponseCode { get; set; } = null!;
        public DateTime RequestedOn { get; set; }
        public DateTime RespondedOn { get; set; }
        public bool IsSuccessStatusCode { get; set; }
    }
}
