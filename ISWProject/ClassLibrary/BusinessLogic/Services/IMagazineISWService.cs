﻿    using Magazine.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Magazine.Services
{
    public interface IMagazineISWService
    {

        // YOU MAY ADD ANY ADDITIONAL NEEDED SERVICES TO THIS INTERFACE
        bool IsValidEmail(string email);
        int GetLastIssueNumberAndAddANewOne();
        List<string> GetAllAreasNames();
        List<Paper> GetAllPublicationPendingPapersInAnArea(string areaName);
        List<Paper> GetAllEvaluationPendingPapersInAnArea(string areaName);
        Paper GetPaperById(int id);
        void BuildAnIssue(DateTime newPublicationDate);
        ICollection<Paper> GetAllPublishedPapersInTheLastIssue();

        /// <summary>   Initializes Database with some data</summary>        
        void DBInitialization();

        #region User

        /// <summary>   Performs login validation and logs in </summary>
        /// <param>     <c>login</c> is the user login name 
        /// </param>
        /// <param>     <c>password</c> is the user password for login. 
        /// </param>
        /// <returns>   Any required ServiceExceptions
        ///             userId if login succeeds
        /// </returns>
        string Login(string login, string password);

        /// <summary>   Performs a log out operation </summary>
        void Logout();

        bool CheckUsername(string username);


        /// <summary>   Performs User info validation and registers a new user. </summary>
        /// <param>     <c>id</c> is the user identification. 
        /// </param>
        /// <param>     <c>name</c> is the user first name. 
        /// </param>
        /// <param>     <c>surname</c> is the user last name. 
        /// </param>
        /// <param>     <c>alerted</c> is the user willingness to be alerted. 
        /// </param>
        /// <param>     <c>areasOfInterest</c> text describing the areas the user is interested in. 
        /// </param>
        /// <param>     <c>email</c> user email address. 
        /// </param>
        /// <param>     <c>login</c> is the user login name 
        /// </param>
        /// <param>     <c>password</c> is the user password for login. 
        /// </param>
        /// <returns>   Any required ServiceExceptions
        /// </returns>
        void RegisterUser(string id, string name, string surname, bool alerted, string areasOfInterest, string email, string login, string password);

        User GetCurrentUser();

        #endregion

        #region Paper

        bool IsPublished(int paperId);

        /// <summary>   Validate data, if correct, register paper submission with logged user.</summary>
        /// <param>     <c>areaid</c> is the id of the area to which the paper is submitted. 
        /// </param>
        /// <param>     <c>title</c> is the paper title. 
        /// </param>
        /// <param>     <c>uploadDate</c> is the submission date 
        /// </param>   
        /// <returns>
        ///             paper Id
        ///             Any required ServiceExceptions 
        /// </returns>
        int SubmitPaper(int areaId, string title, DateTime uploadDate);

        void RegisterPerson(string id, string name, string surname);

        void AddCoauthor(int paperId, string id);

        /// <summary>   Validate data, if correct, register paper evaluation.</summary>
        /// <param>     <c>accepted</c> is the result of the evaluation. 
        /// </param>
        /// <param>     <c>comments</c> is the text describing comments made by the area editor
        /// </param>
        /// <param>     <c>date</c> is the date of the evaluation
        /// </param>
        /// <param>     <c>paperId</c> is the id of the evaluated paper. 
        /// </param>
        /// <returns>   
        ///             Any required ServiceExceptions 
        /// </returns>
        void EvaluatePaper(bool accepted, string comments, DateTime date, int paperId);

        /// <summary>   Register paper publication if current open issue exists</summary>
        /// <param>     <c>paperId</c> is the Id of the paper to be published in the current issue. 
        /// </param>
        /// <returns>   
        ///             Any required ServiceExceptions
        /// </returns>
        void PublishPaper(int paperId);

        /// <summary>   Validate data, if correct, unpublish paper (it returns to pending publication).</summary>
        /// <param>     <c>paperId</c> is the Id of the paper to be published in the issue. 
        /// </param>
        /// <returns>   
        ///             Any required ServiceExceptions
        /// </returns>
        void UnPublishPaper(int paperId);

        /// <summary>   Validate data and return whether it is evaluation pending </summary>
        /// <param>     <c>paperId</c> is the Id of the paper. 
        /// </param>
        /// <returns>   
        ///             Any required ServiceExceptions 
        ///             true if paper is evaluation pending, false otherwise
        /// </returns>
        bool isEvaluationPending(int paperId);

        /// <summary>   Validate data and return whether it is publication pending </summary>
        /// <param>     <c>paperId</c> is the Id of the paper. 
        /// </param>
        /// <returns>   
        ///             Any required ServiceExceptions 
        ///             true if paper is publication pending, false otherwise
        /// </returns>
        /// 
        bool isPublicationPending(int paperId);

        /// <summary>   Validate data and return whether it is Accepted </summary>
        /// <param>     <c>paperId</c> is the Id of the paper. 
        /// </param>
        /// <returns>   
        ///             Any required ServiceExceptions
        ///             true if paper is Accepted, false otherwise
        /// </returns>
        bool isAccepted(int paperId);

        List<Paper> ListAllEvaluationPendingPapers();

        #endregion

        #region Issue

        /// <summary>   Validate data and Add a new issue.</summary>
        /// <param>     <c>number</c> is the issue number. 
        /// </param>     
        /// <returns> 
        ///             Issue Id
        ///             Any required ServiceExceptions 
        /// </returns>
        int AddIssue(int number);

        #endregion

        #region Area

        /// <summary>   validate data and if correct, Add a new area.</summary>
        /// <param>     <c>areaName</c> is the area name. 
        /// </param>     
        /// <param>     <c>editorId</c> is the Id of the area editor. 
        /// </param>
        /// <returns> 
        ///             Area Id
        ///             Any required ServiceExceptions 
        /// </returns>
        int AddArea(string areaName, string editorId);

        int GetIdByAreaName(string areaName);

        #endregion

        #region Magazine

        /// <summary>   Validate data and Add a new magazine with its chief editor.</summary>
        /// <param>     <c>name</c> is the name of the magazine 
        /// </param>
        /// <param>     <c>chiefEditorId</c> is the is the user Id of that becomes chief Editor 
        /// </param>
        /// <returns>   
        ///             Magazine Id
        ///             Any required ServiceExceptions
        /// </returns>
        int AddMagazine(string name, string chiefEditorId);

        List<Paper> ListAllPapers();

        List<Paper> ListPapersByArea(Area a);

        List<Person> ListAllPersons();

        bool IsAreaEditor(User user, out string area);

        bool IsChiefEditor(User user);
        List<Area> ListAllAreas();
        #endregion
    }
}
