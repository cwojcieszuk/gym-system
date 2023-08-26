using MediatR;
using Microsoft.AspNetCore.Http;

namespace Gymify.Application.Profile.Commands.UploadAvatar;

public record UploadAvatarCommand(Guid UserUid, IFormFile File): IRequest<Unit>;