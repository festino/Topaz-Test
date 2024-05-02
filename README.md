## Текст задания

Дана реализация [SomeViewModel](https://github.com/festino/Topaz-Test/blob/main/TopazTest/ViewModels/SomeViewModel.cs).

Необходимо реализовать метод GetData в классе SomeSource, при вызове которого отображается форма, изображенная ниже. Отображаться должен один экземпляр формы.

<img height="300px" alt="Popup Design" src="https://raw.githubusercontent.com/festino/Topaz-Test/main/Images/PopupDesign.png"/>

Пользователь вводит значение в текстовое поле. Нажимает ОК. Метод GetData возвращает значение из текстового поля. Введенное значение отображается на основной форме. Без введенного значения ОК нажиматься не должен. Форма закрывается только при нажатии ОК.

Использовать метод ShowDialog() класса Window нельзя. Использовать WinForms подсистему нельзя.

Результат желательно прислать в виде проекта (WPF или Avalonia приложение без обращения к подсистеме WinForms) который можно открыть и собрать в MS Visual Studio.

## Выводы по работе

Основная сложность - вызвать [Window.Show()](https://github.com/dotnet/wpf/blob/cfb63069b73e9a10a6ccb5835f4dadda6b119e92/src/Microsoft.DotNet.Wpf/src/PresentationFramework/System/Windows/Window.cs#L172) так, чтобы не заблокировать поток UI. Нашёл решение через [Dispatcher.PushFrame(DispatcherFrame frame)](https://github.com/dotnet/wpf/blob/cfb63069b73e9a10a6ccb5835f4dadda6b119e92/src/Microsoft.DotNet.Wpf/src/WindowsBase/System/Windows/Threading/Dispatcher.cs#L313): при вызове метода управление передаётся снова в цикл обработки UI, что позволяет не блокировать поток и работать как с новым окном, так и с предыдущим.

Для воссоздания дизайна формы необходимо было убрать кнопки из заголовка окна и контекстное меню, ведь через него также можно было бы закрыть окно. Для этого я нашёл два варианта: либо поставить WindowStyle="None" и перезаписать стиль окна с нуля, либо обратиться к Win32, чтобы убрать кнопки. Я выбрал второй вариант.

В ограничениях на задание фигурирует запрет на "подсистему WinForms", но Win32, насколько я понимаю, находится на более низком уровне, чем WinForms. Понятно, что от этих вызовов теряется кроссплатформенность, но она явно не указана в требованиях, что на реальном проекте, конечно, уточнилось бы сразу. При необходимости, нетрудно заменить реализацию и на вариант с переписыванием стиля. У переписывания стиля я вижу следующие недостатки: окно будет выглядеть ненативно, придётся заново реализовать перетаскивание окна за заголовок.
