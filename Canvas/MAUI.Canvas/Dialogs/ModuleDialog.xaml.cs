using Canvas.Models;
using MAUI.Canvas.ViewModels;

namespace MAUI.Canvas.Dialogs;

[QueryProperty(nameof(ModuleId), "moduleId")]
[QueryProperty(nameof(CourseId), "courseId")]
public partial class ModuleDialog : ContentPage
{
    public int ModuleId
    {
        get; set;
    }

    public int CourseId
    {
        get; set;
    }

    public ModuleDialog()
    {
        InitializeComponent();
        BindingContext = new ModuleDialogViewModel(0);
    }

    private void CancelClicked(object sender, EventArgs e)
    {
        var myCourseId = (BindingContext as ModuleDialogViewModel)?.CourseId;
        Shell.Current.GoToAsync($"//CourseDialog?courseId={myCourseId}");
    }

    private void OkClicked(object sender, EventArgs e)
    {
        var myCourseId = (BindingContext as ModuleDialogViewModel)?.CourseId;
        (BindingContext as ModuleDialogViewModel)?.AddModule();
        Shell.Current.GoToAsync($"//CourseDialog?courseId={myCourseId}");
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        if(CourseId == 0)   // Creating a new module
        {
            BindingContext = new ModuleDialogViewModel(ModuleId);
        }
        else    // Updating a module
        {
            BindingContext = new ModuleDialogViewModel(ModuleId, CourseId);
        }
       
    }

}