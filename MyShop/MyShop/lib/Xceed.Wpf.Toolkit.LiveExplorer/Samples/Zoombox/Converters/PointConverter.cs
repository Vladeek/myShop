/***************************************************************************************

   Toolkit for WPF

   Copyright (C) 2007-2017 Xceed Software Inc.

   This program is provided to you under the terms of the Microsoft Public
   License (Ms-PL) as published at http://wpftoolkit.codeplex.com/license 

   For more features, controls, and fast professional support,
   pick up the Plus Edition at https://xceed.com/xceed-toolkit-plus-for-wpf/

   Stay informed: follow @datagrid on Twitter or Like http://facebook.com/datagrids

  *************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace Xceed.Wpf.Toolkit.LiveExplorer.Samples.Zoombox.Converters
{
  public class PointConverter : SimpleConverter
  {
    protected override object Convert( object value )
    {
      return PointConverter.ConvertPoint( ( Point )value );
    }

    public static string ConvertPoint( Point point )
    {
      return string.Format( "{0},{1}",
        Math.Round( point.X ), Math.Round( point.Y ) );
    }
  }
}
