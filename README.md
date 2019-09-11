# Kentico 12 MVC Font Awesome Form Component
font-awesome-form-component for Kentico MVC, adds the ability for a content editor to select a Font Awesome 5.x icon from a modal popup.

## Nuget Package
https://www.nuget.org/packages/NetC.FontAwesomeFormComponent.Kentico.MVC/

## Example use
1. Include a property within an MVC widget property class:
```
[EditingComponent(FontAwesomeIconSelectorComponent.IDENTIFIER, Label = "Icon")]
/// <summary>
/// Icon field input.
/// </summary>
public string Icon { get; set; }
```

2. Complete setting up the MVC widget itself, passing the Icon field through to the widget view, e.g.:
```
<i class="@Model.Icon"></i>
```

3. Ensure your MVC site's layout contains Font Awesome CSS/JS, e.g.:
```
<!DOCTYPE html>

<html>
<head id="head">
    ...
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.10.2/css/all.min.css" integrity="sha256-zmfNZmXoNWBMemUOo1XUGFfc0ihGGLYdgtJS3KCr/l0=" crossorigin="anonymous" />
        <script type="text/javascript">
        // Notice how this gets configured before we load Font Awesome
        window.FontAwesomeConfig = { autoReplaceSvg: false }
    </script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.10.2/js/all.min.js" integrity="sha256-iZGp5HAiwRmkbOKVYv5FUER4iXp5QbiEudkZOdwLrjw=" crossorigin="anonymous"></script>
</head>
```

4. Add the widget to an MVC page, and open the config window to see the new property available:
![form component image](https://github.com/liamgold/font-awesome-form-component/blob/master/img/FormComponent.PNG?raw=true)

5. Clicking the 'Open dialog' button opens the icon selection modal popup:
![form component modal image](https://github.com/liamgold/font-awesome-form-component/blob/master/img/FormComponentModal.PNG?raw=true)

## ⌨️ Contributions, 🐛 bug fixes and 📜 license
Feel free to Fork and submit pull requests to contribute.

You can submit bugs through the issue list and we will get to them as soon as we can, unless you want to fix it yourself and submit a pull request!

Check the LICENSE.txt for License information

## Compatibility
Can be used on any Kentico 12 SP site (hotfix 29 or above).
