using OpenAI.Chat;
using System.ClientModel;
namespace BlazorChatGPT.Services
{
    public class GPTService
    {
        #region [00] Shared Variables
        private ChatClient _chatClient;
        #endregion
        #region [01] Constractor of GPTService
        public GPTService(string gptModel="gpt-4o-mini")
        {
            _chatClient = new ChatClient(
                model: gptModel,
                apiKey: Environment.GetEnvironmentVariable("OPENAI_APIKEY"));
             
        }
        #endregion
        #region [02] Chat Completion method - non-streaming mode
        //public ChatCompletion GetResponse(string prompt)
        //{
        //    ChatCompletion result= _chatClient.CompleteChat(prompt);
        //    return result;
        //}   
        //public async Task<ChatCompletion> GetResponseAsync(string prompt)
        //{
        //    ChatCompletion result= await _chatClient.CompleteChatAsync(prompt);
        //    return result;
        //}
        #endregion
        #region [03] Chat Completion method - streaming mode
        public AsyncCollectionResult<StreamingChatCompletionUpdate> GetStreamingResponseAsync(string prompt)
        {
            ChatCompletionOptions options = new ChatCompletionOptions();
            options.MaxOutputTokenCount = 1000;
            List<ChatMessage> messages = 
                [ChatMessage.CreateSystemMessage("Your name is Bombardini Corcodili and You are a helpful assistant."),
                ChatMessage.CreateUserMessage(prompt)];

            AsyncCollectionResult<StreamingChatCompletionUpdate> completionUpdates = 
                _chatClient.CompleteChatStreamingAsync(messages, options);
            return completionUpdates;
        }
        #endregion
    }
}
