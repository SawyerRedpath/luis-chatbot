using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Schema;
using Microsoft.Extensions.Logging;

namespace BasicBot.Dialogs.Help
{
    public class HelpDialog : ComponentDialog
    {
        private const string GetHelpDialog = "getHelpDialog";
        private const string HelpPrompt = "helpPrompt";

        public HelpDialog(IStatePropertyAccessor<HelpState> helpStateAccessor, ILoggerFactory loggerFactory)
            : base(nameof(HelpDialog))
        {
            // Add control flow dialogs
            //var waterfallSteps = new WaterfallStep[]
            //{
            //        CategoryStepAsync,
            //};
            //AddDialog(new WaterfallDialog(GetHelpDialog, waterfallSteps));
            //AddDialog(new TextPrompt(HelpPrompt, ValidateHelp));
        }

        private async Task<DialogTurnResult> CategoryStepAsync(ITurnContext turnContext, WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
          // Suggest Action using button
           var reply = turnContext.Activity.CreateReply("What would you like help with?");

           reply.SuggestedActions = new SuggestedActions()
            {
                Actions = new List<CardAction>()
                {
                    new CardAction() { Title = "Pathway", Type = ActionTypes.ImBack, Value = "Pathway" },
                    new CardAction() { Title = "Curriculm", Type = ActionTypes.ImBack, Value = "Curriculum" },
                    new CardAction() { Title = "Motivational Quotes", Type = ActionTypes.ImBack, Value = "Motivational Quotes" },
                    new CardAction() { Title = "Job Search", Type = ActionTypes.ImBack, Value = "Job Search" },
                },

            };

           await turnContext.SendActivityAsync(reply, cancellationToken);

           return await stepContext.NextAsync();
        }
    }
}
