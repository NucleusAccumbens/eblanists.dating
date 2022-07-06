using FluentValidation;

namespace Application.TelegramUsers.Commands.CreateTelegramUser
{
    public class CreateTelegramUserCommandChatIdValidator : AbstractValidator<CreateTelegramUserCommand>
    {
        private readonly IDatingAppDbContext _context;

        public CreateTelegramUserCommandChatIdValidator(IDatingAppDbContext context)
        {
            _context = context;

            RuleFor(u => u.ChatId.ToString())
                .MinimumLength(6).WithMessage("ChatId must be at least 6 digits.");

            RuleFor(u => u.ChatId)
                .MustAsync(BeUniqueChatId).WithMessage("The specified ChatId already exists.");
        }

        private async Task<bool> BeUniqueChatId(long chatId, CancellationToken cancellationToken)
        {
            return await _context.TelegramUsers
                .AllAsync(u => u.ChatId != chatId, cancellationToken);
        }
    }
}
