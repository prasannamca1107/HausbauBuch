﻿using System;

namespace HausbauBuch.Classes
{
    public class Appointments : Entity
    {
        private string _title;

        public string Title
        {
            get { return _title; }
            set
            {
                if (value.Equals(_title))
                {
                    return;
                }
                _title = value;
                OnPropertyChanged();
            }
        }

        private string _detail;

        public string Detail
        {
            get {  return _detail; }
            set
            {
                if (value.Equals(_detail))
                {
                    return;
                }
                _detail = value;
                OnPropertyChanged();
            }
        }

        private string _place;

        public string Place
        {
            get { return _place; }
            set
            {
                if (value.Equals(_place))
                {
                    return;
                }
                _place = value;
                OnPropertyChanged();
            }
        }
        
        private DateTime _startTime;

        public DateTime StartTime
        {
            get { return _startTime; }
            set
            {
                if (value.Equals(_startTime))
                {
                    return;
                }
                _startTime = value;
                OnPropertyChanged();
            }
        }

        private DateTime _endTime;

        public DateTime EndTime
        {
            get { return _endTime; }
            set
            {
                if (value.Equals(_endTime))
                {
                    return;
                }
                _endTime = value;
                OnPropertyChanged();
            }
        }

        private DateTime _startDate;

        public DateTime StartDate
        {
            get { return _startDate; }
            set
            {
                if (value.Equals(_startDate))
                {
                    return;
                }
                _startDate = value;
                OnPropertyChanged();
            }
        }

        private DateTime _endDate;

        public DateTime EndDate
        {
            get {  return _endDate; }
            set
            {
                if (value.Equals(_endDate))
                {
                    return;
                }
                _endDate = value;
                OnPropertyChanged();
            }
        }

        private DateTime _combinedStartDate;

        public DateTime CombinedStartdate
        {
            get { return _combinedStartDate; }
            set
            {
                if (value.Equals(_combinedStartDate))
                {
                    return;
                }
                _combinedStartDate = value;
                OnPropertyChanged();
            }
        }

        private DateTime _combinedEndDate;

        public DateTime CombinedEndDate
        {
            get { return _combinedEndDate; }
            set
            {
                if (value.Equals(_combinedEndDate))
                {
                    return;
                }
                _combinedEndDate = value;
                OnPropertyChanged();
            }
        }

        public Appointments()
        {
            Title = "";
            Detail = "";
            Place = "";
            StartTime = DateTime.Now;
            EndTime = DateTime.Now.AddHours(1);
            StartDate = DateTime.Today;
            EndDate = DateTime.Today;
        }
    }
}
