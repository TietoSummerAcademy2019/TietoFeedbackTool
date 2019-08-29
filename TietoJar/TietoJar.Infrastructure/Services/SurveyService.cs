using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using TietoJar.Application.Interfaces;
using TietoJar.Persistence;
using TietoJar.Domain;
using System;
using Microsoft.EntityFrameworkCore;

namespace TietoJar.Infrastructure.Services
{
    public class SurveyService : ISurveyService
    {
        public readonly ITietoJarContext _context;

        public SurveyService(ITietoJarContext context)
        {
            _context = context;
        }
        //Survey
        public Survey AddSurvey(Survey survey)
        {
            _context.Surveys.Add(survey);
            _context.SaveChanges();
            return survey;
        }

        public void DeleteSurvey(string surveyKey)
        {
            var survey = _context.Surveys.Where(x => x.SurveyKey == surveyKey).FirstOrDefault();
            _context.Surveys.Remove(survey);
            _context.SaveChanges();
        }

        public Survey GetSurvey(string surveyKey)
        {
            return _context.Surveys.SingleOrDefault(x => x.SurveyKey == surveyKey);
        }

        public List<Survey> GetSurveys()
        {
            return _context.Surveys.ToList();
        }

        public Survey UpdateSurvey(string surveyKey, Survey survey)
        {
            var _survey = _context.Surveys.SingleOrDefault(x => x.SurveyKey == surveyKey);
            _survey.Name = survey.Name;
            _survey.AccountLogin = survey.AccountLogin;
            _context.SaveChanges();
            return survey;
        }

        //SurveyPuzzle
        public SurveyPuzzle AddSurveyPuzzle(SurveyPuzzle surveyPuzzle)
        {
            _context.SurveyPuzzles.Add(surveyPuzzle);
            _context.SaveChanges();
            return surveyPuzzle;
        }
        public List<SurveyPuzzle> GetSurveyPuzzles()
        {
            var surveyPuzzle = _context.SurveyPuzzles.ToList();
            return surveyPuzzle;
        }

        public SurveyPuzzle GetSurveyPuzzle(int id)
        {
            return _context.SurveyPuzzles.SingleOrDefault(x => x.Id == id);
        }

        public SurveyPuzzle UpdateSurveyPuzzle(int id, SurveyPuzzle surveyPuzzle)
        {
            var _surveyPuzzle = _context.SurveyPuzzles.SingleOrDefault(x => x.Id == id);
            _surveyPuzzle.PuzzleTypeId = surveyPuzzle.PuzzleTypeId;
            _surveyPuzzle.SurveyKey = surveyPuzzle.SurveyKey;
            _surveyPuzzle.PuzzleQuestion = surveyPuzzle.PuzzleQuestion;
            _surveyPuzzle.Position = surveyPuzzle.Position;
            _context.SaveChanges();
            return surveyPuzzle;
        }

        public void DeleteSurveyPuzzle(int id)
		{
		    var surveyPuzzle = _context.SurveyPuzzles.Where(x => x.Id == id).FirstOrDefault();
			_context.SurveyPuzzles.Remove(surveyPuzzle);
            _context.SaveChanges();
		}

        //PuzzleType
        public PuzzleType AddPuzzleType(PuzzleType puzzleType)
        {
            _context.PuzzleTypes.Add(puzzleType);
            _context.SaveChanges();
            return puzzleType;
        }

        public List<PuzzleType> GetPuzzleTypes()
        {
            return _context.PuzzleTypes.ToList();
        }

		public PuzzleType GetPuzzleType(int id)
        {
            return _context.PuzzleTypes.SingleOrDefault(x => x.Id == id);
        }

        public PuzzleType UpdatePuzzleType(int id, PuzzleType puzzleType)
        {
            var _puzzleType = _context.PuzzleTypes.SingleOrDefault(x => x.Id == id);
            _puzzleType.Name = puzzleType.Name;
            _puzzleType.HaveOpenAnswer = puzzleType.HaveOpenAnswer;
            _context.SaveChanges();
            return puzzleType;
        }

		public void DeletePuzzleType(int id)
        {
            var puzzleType = _context.PuzzleTypes.Where(x => x.Id == id).FirstOrDefault();
            _context.PuzzleTypes.Remove(puzzleType);
            _context.SaveChanges();
        }
    }
 }