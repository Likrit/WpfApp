using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WpfApp1.Infrastructure.Commands;
using WpfApp1.ViewModels.Base;
using static System.Int32;

namespace WpfApp1.ViewModels
{
    public class MainWindowViewModel : ViewModel
    {
        string _leftop = ""; // Левый операнд
        string _operation = ""; // Знак операции
        string _rightop = ""; // Правый операнд
        private string _text;

        public string Text
        {
            get => _text;
            set
            {
                _text = value;
                OnPropertyChanged();
            }
        }

        public ActionCommand AddButton
        {
            get
            {
                return new ActionCommand((obj) =>
                {
                   
                        Button_Click(obj.ToString());
                    
                });
            }
        }

        private void Button_Click(string s)
        {
            // Добавляем его в текстовое поле
            Text += s;
            int num;
            // Пытаемся преобразовать его в число
            bool result = TryParse(s, out num);
            // Если текст - это число
            if (result)
            {
                // Если операция не задана
                if (_operation == "")
                {
                    // Добавляем к левому операнду
                    _leftop += s;
                }
                else
                {
                    // Иначе к правому операнду
                    _rightop += s;
                }
            }
            // Если было введено не число
            else
            {
                // Если равно, то выводим результат операции
                if (s == "=")
                {
                    Update_RightOp();
                    Text += _rightop;
                    _operation = "";
                }
                // Очищаем поле и переменные
                else if (s == "CLEAR")
                {
                    _leftop = "";
                    _rightop = "";
                    _operation = "";
                    Text = "";
                }
                // Получаем операцию
                else
                {
                    // Если правый операнд уже имеется, то присваиваем его значение левому
                    // операнду, а правый операнд очищаем
                    if (_rightop != "")
                    {
                        Update_RightOp();
                        _leftop = _rightop;
                        _rightop = "";
                    }

                    _operation = s;
                }
            }
        }

        // Обновляем значение правого операнда
        private void Update_RightOp()
        {
            int num1 = Parse(_leftop);
            int num2 = Parse(_rightop);
            // И выполняем операцию
            switch (_operation)
            {
                case "+":
                    _rightop = (num1 + num2).ToString();
                    break;
                case "-":
                    _rightop = (num1 - num2).ToString();
                    break;
                case "*":
                    _rightop = (num1 * num2).ToString();
                    break;
                case "/":
                    _rightop = (num1 / num2).ToString();
                    break;
            }
        }
    }
}

