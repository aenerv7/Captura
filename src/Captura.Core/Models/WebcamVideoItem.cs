﻿using System;
using System.Drawing;
using Captura.ViewModels;
using Captura.Webcam;

namespace Captura.Models
{
    public class WebcamVideoItem : NotifyPropertyChanged, IVideoItem
    {
        readonly WebcamModel _webcamModel;

        public WebcamVideoItem(WebcamModel WebcamModel)
        {
            _webcamModel = WebcamModel;

            _webcamModel.PropertyChanged += (S, E) => RaisePropertyChanged(nameof(Name));
        }

        public string Name => _webcamModel.SelectedCam?.Name;

        public IImageProvider GetImageProvider(bool IncludeCursor, out Func<Point, Point> Transform)
        {
            Transform = P => P;

            return new WebcamImageProvider(_webcamModel);
        }
    }
}