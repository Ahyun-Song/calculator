using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calculating_machine
{
    public partial class Form1 : Form
    {
        calculate cal = new calculate();
        string before_Value = "";
        string current_Value = "";
        string result_Value = "";
        string operation = "";

        public Form1()
        {
            InitializeComponent();
        }

        // 숫자 버튼 클릭 이벤트 처리
        private void button_number_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                current_Value += btn.Text; // 숫자 추가
                textBox_presentvalue.Text = current_Value;
                textBox_prevalue.Text = $"{result_Value} {operation} {current_Value}".Trim(); // 연산자 및 이전 값 표시
            }
        }

        // 연산자 버튼 클릭 처리
        private void button_operator_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(current_Value))
            {
                if (string.IsNullOrEmpty(result_Value))
                {
                    result_Value = current_Value; // 첫 번째 숫자는 바로 result_Value에 저장
                }
                else
                {
                    result_Value = PerformCalculation(result_Value, current_Value, operation); // 기존 값과 연산 수행
                }
                operation = (sender as Button)?.Text; // 연산자 저장
                textBox_prevalue.Text = $"{result_Value} {operation}"; // 연산자 표시
                current_Value = ""; // 현재 값 초기화
                textBox_presentvalue.Text = "";
            }
        }

        // Equal 버튼 클릭 처리
        private void button_equal_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(current_Value) && !string.IsNullOrEmpty(operation))
            {
                result_Value = PerformCalculation(result_Value, current_Value, operation);
                textBox_prevalue.Text = $"{result_Value}"; // 계산된 결과 출력
                textBox_presentvalue.Text = "";
                current_Value = "";
                operation = "";
            }
        }

        // 사칙연산 수행
        private string PerformCalculation(string value1, string value2, string op)
        {
            switch (op)
            {
                case "+":
                    return cal.addtion(value1, value2);
                case "-":
                    return cal.subtraction(value1, value2);
                case "*":
                    return cal.multiplication(value1, value2);
                case "/":
                    return cal.division(value1, value2);
                default:
                    return value1;
            }
        }

        // Clear 버튼 (CE) 클릭 처리
        private void button_ce_Click(object sender, EventArgs e)
        {
            current_Value = "";
            result_Value = "";
            before_Value = "";
            operation = "";
            textBox_presentvalue.Text = "";
            textBox_prevalue.Text = "";
        }

        private void button_c_Click(object sender, EventArgs e)
        {
            current_Value = "";
            textBox_presentvalue.Text = "";
            operation = "";
        }

        // Backspace 버튼 클릭 처리
        private void button_backspace_Click(object sender, EventArgs e)
        {
            if (current_Value.Length > 0)
            {
                current_Value = current_Value.Substring(0, current_Value.Length - 1);
                textBox_presentvalue.Text = current_Value;
            }
        }

        // 소수점 버튼 클릭 처리
        private void button_float_Click(object sender, EventArgs e)
        {
            if (!current_Value.Contains("."))
            {
                current_Value += ".";
                textBox_presentvalue.Text = current_Value;
            }
        }

        // 부호 변환 버튼 클릭 처리
        private void button_covertsign_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(current_Value))
            {
                double value = double.Parse(current_Value) * -1;
                current_Value = value.ToString();
                textBox_presentvalue.Text = current_Value;
            }
        }

        private void button_spuare_Click(object sender, EventArgs e)
        {
            if (result_Value == "")
            {
                result_Value = cal.GetSquare_Value(textBox_presentvalue.Text);
            }
            current_Value = "";
            textBox_prevalue.Text = result_Value;
            textBox_presentvalue.Text = "";
        }

        private void button_squareroot_Click(object sender, EventArgs e)
        {
            if (result_Value == "")
            {
                result_Value = cal.GetRoot_Value(textBox_presentvalue.Text);
                if (result_Value == "입력이 잘못되었습니다.")
                {
                    textBox_presentvalue.Text = result_Value;
                    result_Value = "";
                    textBox_prevalue.Text = "";
                }
                else
                {
                    current_Value = "";
                    textBox_prevalue.Text = result_Value;
                    textBox_presentvalue.Text = "";
                }
            }
        }

        private void button_invert_Click(object sender, EventArgs e)
        {
            if (result_Value == "")
            {
                result_Value = cal.GetInverse_Value(textBox_presentvalue.Text);
                if (result_Value == "0으로 나누지 마세요!")
                {
                    textBox_presentvalue.Text = result_Value;
                    result_Value = "";
                    textBox_prevalue.Text = "";
                }
                else
                {
                    current_Value = "";
                    textBox_prevalue.Text = result_Value;
                    textBox_presentvalue.Text = "";
                }
            }
        }

        private void button_percent_Click(object sender, EventArgs e)
        {
            if (result_Value == "")
            {
                result_Value = cal.GetPercentage_Value(textBox_presentvalue.Text);
                current_Value = "";
                textBox_prevalue.Text = result_Value;
                textBox_presentvalue.Text = "";
            }
        }

        // 숫자 버튼 클릭: 1~9, 0
        private void button_number1_Click(object sender, EventArgs e) => button_number_Click(sender, e);
        private void button_number2_Click(object sender, EventArgs e) => button_number_Click(sender, e);
        private void button_number3_Click(object sender, EventArgs e) => button_number_Click(sender, e);
        private void button_number4_Click(object sender, EventArgs e) => button_number_Click(sender, e);
        private void button_number5_Click(object sender, EventArgs e) => button_number_Click(sender, e);
        private void button_number6_Click(object sender, EventArgs e) => button_number_Click(sender, e);
        private void button_number7_Click(object sender, EventArgs e) => button_number_Click(sender, e);
        private void button_number8_Click(object sender, EventArgs e) => button_number_Click(sender, e);
        private void button_number9_Click(object sender, EventArgs e) => button_number_Click(sender, e);
        private void button_number0_Click(object sender, EventArgs e) => button_number_Click(sender, e);

        // 연산자 버튼 클릭: +, -, *, /
        private void button_add_Click(object sender, EventArgs e) => button_operator_Click(sender, e);
        private void button_subtract_Click(object sender, EventArgs e) => button_operator_Click(sender, e);
        private void button_multiple_Click(object sender, EventArgs e) => button_operator_Click(sender, e);
        private void button_divide_Click(object sender, EventArgs e) => button_operator_Click(sender, e);
    }
}