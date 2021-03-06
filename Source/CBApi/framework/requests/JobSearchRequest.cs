﻿using System;
using System.Collections.Generic;
using System.Text;
using com.careerbuilder.api.models;
using com.careerbuilder.api.models.service;
using com.careerbuilder.api.models.responses;

namespace com.careerbuilder.api.framework.requests
{
    internal class JobSearchRequest : GetRequest, IJobSearch
    {
        protected string _Keywords = "";
        protected string _CompanyName = "";
        protected string _Location = "";
        protected int _Radius = 30;
        protected string _CountryCode = "US";
        protected List<string> _CategoryCodes = new List<string>();
        protected string _Soccode = "";
        protected string _EducationCode = "";
        protected bool _SpecificEducation = false;
        protected int _PostedWithin = 30;
        protected List<string> _EmployeeTypes = new List<string>();
        protected int _MinPay = -1;
        protected int _MaxPay = -1;
        protected int _OffSet = 1;
        protected int _PerPage = 25;
        protected OrderByType _OrderBy = OrderByType.Relevance;
        protected OrderDirection _OrderDirection = OrderDirection.Descending;
        protected BooleanOperator _BooleanOperator = BooleanOperator.AND;
        protected bool ExcludeNationwideJobs = true;

        public JobSearchRequest(string key, string domain, string cobrand, string siteid)
            : base(key, domain, cobrand, siteid)
        {

        }

        public override string BaseURL
        {
            get { return "/v1/jobsearch"; }
        }

        public ResponseJobSearch Search()
        {
            base.BeforeRequest();
            AddParametersToRequest();
            var response = _client.Execute<ResponseJobSearch>(_request);
            return response.Data;
        }
        #region setup request
        protected void AddParametersToRequest()
        {
            AddKeywordsToRequest();
            AddCompanyNameToRequest();
            AddLocationToRequest();
            AddRadiusToRequest();
            AddCountryCodeToRequest();
            AddCategoriesToRequest();
            AddSOCCodeToRequest();
            AddEducationToRequest();
            AddPostedWithinToRequest();
            AddEmployeeTypesToRequest();
        }

        private void AddEmployeeTypesToRequest()
        {
            if (_EmployeeTypes.Count > 0)
            {
                string emps = string.Join(",", _EmployeeTypes);
                _request.AddParameter("EmpType", emps);
            }
        }

        private void AddPostedWithinToRequest()
        {
            if (_PostedWithin >= 1 && _PostedWithin <= 30)
            {
                _request.AddParameter("PostedWithin", _PostedWithin.ToString());
            }
        }

        private void AddEducationToRequest()
        {
            if (!string.IsNullOrEmpty(_EducationCode))
            {
                _request.AddParameter("EducationCode", _EducationCode);
                _request.AddParameter("SpecificEducation", _SpecificEducation.ToString());
            }
        }

        private void AddSOCCodeToRequest()
        {
            if (!string.IsNullOrEmpty(_Soccode))
            {
                _request.AddParameter("SOCCode", _Soccode);
            }
        }

        private void AddCategoriesToRequest()
        {
            if (_CategoryCodes.Count > 0 && _CategoryCodes.Count <= 10)
            {
                string cats = string.Join(",", _CategoryCodes);
                _request.AddParameter("Category", cats);
            }
        }

        private void AddCountryCodeToRequest()
        {
            if (!string.IsNullOrEmpty(_CountryCode))
            {
                _request.AddParameter("CountryCode", _CountryCode);
            }
        }

        private void AddRadiusToRequest()
        {
            if (_Radius >= 5 && _Radius <= 150)
            {
                _request.AddParameter("Radius", _Radius.ToString());
            }
        }

        private void AddLocationToRequest()
        {
            if (!string.IsNullOrEmpty(_Location))
            {
                _request.AddParameter("Location", _Location);
            }
        }

        private void AddCompanyNameToRequest()
        {
            if (!string.IsNullOrEmpty(_CompanyName))
            {
                _request.AddParameter("CompanyName", _CompanyName);
            }
        }

        private void AddKeywordsToRequest()
        {
            if (!string.IsNullOrEmpty(_Keywords))
            {
                _request.AddParameter("Keywords", _Keywords);
            }
        }
        #endregion

        #region IJobSearch Methods
        public IJobSearch WhereCountryCode(CountryCode value)
        {
            _CountryCode = value.ToString();
            return this;
        }

        public IJobSearch WhereHostSite(HostSite value)
        {
            _CountryCode = value.ToString();
            return this;
        }

        public IJobSearch WhereKeywords(string value)
        {
            _Keywords = value;
            return this;
        }

        public IJobSearch WhereCompanyName(string value)
        {
            _CompanyName = value;
            return this;
        }

        public IJobSearch WhereLocation(string value)
        {
            _Location = value;
            return this;
        }

        public IJobSearch WhereLocation(float latitude, float longitude)
        {
            _Location = latitude.ToString() + "::" + longitude.ToString();
            return this;
        }

        public IJobSearch Radius(int value)
        {
            _Radius = value;
            return this;
        }

        public IJobSearch WhereSOCCode(string value)
        {
            _Soccode = value;
            return this;
        }

        public IJobSearch WherePayGreaterThan(int value)
        {
            _MinPay = value;
            return this;
        }

        public IJobSearch WherePayLessThan(int value)
        {
            _MaxPay = value;
            return this;
        }

        public IJobSearch OrderBy(OrderByType value)
        {
            _OrderBy = value;
            return this;
        }

        public IJobSearch Ascending()
        {
            _OrderDirection = OrderDirection.Ascending;
            return this;
        }

        public IJobSearch Descending()
        {
            _OrderDirection = OrderDirection.Descending;
            return this;
        }

        public IJobSearch SelectTop(int value)
        {
            _PerPage = value;
            return this;
        }

        public IJobSearch Limit(int value)
        {
            _PerPage = value;
            return this;
        }

        public IJobSearch Offset(int value)
        {
            _OffSet = value;
            return this;
        }
        #endregion
    }
}
