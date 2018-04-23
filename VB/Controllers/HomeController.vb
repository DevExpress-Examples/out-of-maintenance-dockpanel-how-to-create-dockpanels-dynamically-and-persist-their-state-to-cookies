Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Mvc

Namespace DockingAddDynamicallyVBMvc.Controllers
	Public Class HomeController
		Inherits Controller
		Public Function Index() As ActionResult
			Return View()
        End Function
        Public Function DockPanelPartial(ByVal index As Integer) As ActionResult
            ViewData("index") = index
            Return PartialView()
        End Function
	End Class
End Namespace
