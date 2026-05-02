using OpenAI.Chat;
using OpenAI.Images;
using System.ClientModel;
using Microsoft.AspNetCore.Hosting;

namespace BlazorChatGPT.Services
{
    public class GPTService
    {
        #region [00] Shared Variables
        private ChatClient _chatClient;
        private ImageClient _imageclient;

        #endregion
        #region [01] Constractor of GPTService
        public GPTService(string gptModel="gpt-4o-mini", string imageModel="dall-e-3")
        {
            _chatClient = new (
                model: gptModel,
                apiKey: Environment.GetEnvironmentVariable("OPENAI_APIKEY"));
            _imageclient = new (
                model: imageModel,
                apiKey: Environment.GetEnvironmentVariable("OPENAI_APIKEY"));
            ;
        }
        #endregion
        #region [02] Chat Completion method - streaming mode
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
        #region [03] Generating Images using OpenAI´s Image API
        public async Task<GeneratedImage> GenerateImageToUriAsync(string prompt)
        {
            ImageGenerationOptions options = new()
                {
                    Quality= GeneratedImageQuality.High,
                    Size = GeneratedImageSize.W1024xH1024,
                    Style = GeneratedImageStyle.Natural,
                    ResponseFormat = GeneratedImageFormat.Uri
            };
            GeneratedImage image = await _imageclient.GenerateImageAsync(prompt,options);
            return image;
        }
        public async Task<GeneratedImage> GenerateImageToBytesAsync(string prompt)
        {
            ImageGenerationOptions options = new()
                {
                    Quality= GeneratedImageQuality.High,
                    Size = GeneratedImageSize.W1024xH1024,
                    Style = GeneratedImageStyle.Natural,
                    ResponseFormat = GeneratedImageFormat.Bytes
            };
            GeneratedImage image = await _imageclient.GenerateImageAsync(prompt,options);
            return image;
        }
        
       
        #endregion
    }
}
