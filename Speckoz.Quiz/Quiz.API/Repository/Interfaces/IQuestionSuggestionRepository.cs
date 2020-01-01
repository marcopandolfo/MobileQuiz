﻿using Quiz.API.Models;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Quiz.API.Repository.Interfaces
{
    public interface IQuestionSuggestionRepository
    {
        Task<QuestionSuggestionModel> CreateTaskAync(QuestionSuggestionModel question);

        Task<List<QuestionSuggestionModel>> GetSuggestionsTaskAsync();

        Task DeleteSuggestionTaskAsync(int id);

        Task ApproveSuggestion(int id);

        Task<QuestionSuggestionModel> FindById(int id);
    }
}