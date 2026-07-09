using UrbanMart.BuildingBlocks.Model.Enum;

namespace UrbanMart.Modules.Identity.Features.RegisterUser
{
    public sealed class Response
    {
        public ResponseStatus Status { get; set; }
        public string? Message { get; set; }
    }
}