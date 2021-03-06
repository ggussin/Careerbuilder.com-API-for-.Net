﻿using System;
using System.Collections.Generic;
using com.careerbuilder.api.framework.requests;
using com.careerbuilder.api.models;
using com.careerbuilder.api.models.service;

namespace com.careerbuilder.api
{
    public class CBApi
    {
        protected TargetSite _TargetSite = null;
        public string DevKey {get;set;}
        public string CobrandCode { get; set; }    //If you are a careerbuilder partner you can set these tracking codes
        public string SiteID { get; set; }         //Otherwise leave these two parameters alone

        public CBApi()
        {
            _TargetSite = new CareerBuilderCom();
            DevKey = Properties.Settings.Default.DevKey;
        }

        public CBApi(string key)
        {
            _TargetSite = new CareerBuilderCom();
            DevKey = key;
        }

        public CBApi(string key,string cobrandCode)
        {
            _TargetSite = new CareerBuilderCom();
            DevKey = key;
            CobrandCode = cobrandCode;
        }

        public CBApi(string key,string cobrandCode, string siteid)
        {
            _TargetSite = new CareerBuilderCom();
            DevKey = key;
            CobrandCode = cobrandCode;
            SiteID = siteid;
        }

        /// <summary>
        /// Make a call to /v1/categories
        /// </summary>
        /// <returns>A Category Request to query against</returns>
        public ICategoryRequest GetCategories()
        {
            return new CategoriesRequest(DevKey, _TargetSite.Domain, CobrandCode, SiteID);
        }

        /// <summary>
        /// Make a call to /v1/employeetypes
        /// </summary>
        /// <returns>A Employee Request to query against</returns>
        public IEmployeeTypesRequest GetEmployeeTypes()
        {
            return new EmployeeTypesRequest(DevKey, _TargetSite.Domain, CobrandCode, SiteID);
        }

        /// <summary>
        /// Make a call to /v1/application/blank
        /// </summary>
        /// <param name="jobDID">The unique ID of the job</param>
        /// <returns>The job</returns>
        public BlankApplication GetBlankApplication(string jobDID)
        {
            var req = new BlankApplicationRequest(jobDID, DevKey, _TargetSite.Domain, CobrandCode, SiteID);
            return req.Retrieve();
        }

        /// <summary>
        /// Make a call to /v1/application/form
        /// </summary>
        /// <param name="jobDID">The unique ID of the job</param>
        /// <returns>The job</returns>
        public string GetApplicationForm(string jobDID)
        {
            var req = new ApplicationFormRequest(jobDID, DevKey, _TargetSite.Domain);
            return req.Retrieve();
        }

        /// <summary>
        /// Submit an application to /v1/application/submit
        /// </summary>
        /// <param name="jobDID">The unique ID of the job</param>
        /// <returns>The job</returns>
        public ResponseApplication SubmitApplication(Application app)
        {
            var req = new SubmitApplicationRequest(_TargetSite.Domain);
            return req.Submit(app);
        }

        /// <summary>
        /// Make a call to /v1/job
        /// </summary>
        /// <param name="jobDID">The unique ID of the job</param>
        /// <returns>The job</returns>
        public Job GetJob(string jobDID)
        {
            var req = new JobRequest(jobDID, DevKey, _TargetSite.Domain, CobrandCode, SiteID);
            return req.Retrieve();
        }

        /// <summary>
        /// Make a call to /v1/job
        /// </summary>
        /// <param name="jobDID">The unique ID of the job</param>
        /// <returns>The job</returns>
        public List<RecommendJobResult> GetRecommendationsForJob(string jobDID)
        {
            var req = new JobRecommendationsRequest(jobDID, DevKey, _TargetSite.Domain, CobrandCode, SiteID);
            return req.GetRecommendations();
        }

        /// <summary>
        /// Make a call to /v1/job
        /// </summary>
        /// <param name="jobDID">The unique ID of the job</param>
        /// <returns>The job</returns>
        public List<RecommendJobResult> GetRecommendationsForUser(string externalID)
        {
            var req = new UserRecommendationsRequest(externalID, DevKey, _TargetSite.Domain, CobrandCode, SiteID);
            return req.GetRecommendations();
        }

        /// <summary>
        /// Make a call to /v1/jobsearch
        /// </summary>
        /// <returns>A Job Request to query against</returns>
        public IJobSearch JobSearch()
        {
            return new JobSearchRequest(DevKey, _TargetSite.Domain, CobrandCode, SiteID);
        }

    }
}
