using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Window_Project
{
    public partial class TicketingChoice : Form
    {

        public TicketingChoice()
        {

            // 폼 실행 후 텍스트 상자에 입력 못하게 만듬 ui용 label로 하기엔 너무 불편해서 이렇게 함
            InitializeComponent();
            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;
            textBox4.ReadOnly = true;

            // UserData.UserPoints를 Label에 표시
            userpoints_label.Text = ($"현재 보유 포인트: {UserData.UserPoints}원");

            // 포인트 변경 이벤트 
            UserData.PointsChanged += UpdateUserPointsLabel;

       
        }

        private void UpdateUserPointsLabel(int newPoints)
        {
            userpoints_label.Text = $"현재 보유 포인트: {newPoints}원";
        }

        // 난이도별 잠금 상태 체크

        private void TicketingChoice_FormClosed(object sender, FormClosedEventArgs e)
        {
            // 폼이 닫힐 때 이벤트 구독 해제
            UserData.PointsChanged -= UpdateUserPointsLabel;
        }

        // 추가적으로 포인트를 변경하거나 업데이트할 수 있는 메서드 추가
        private void UpdatePoints()
        {
            // 예시: 포인트를 차감하거나 변경 후 업데이트
            UserData.UserPoints -= 1000; // 예시로 1000원 차감
            userpoints_label.Text = $"현재 보유 포인트: {UserData.UserPoints}원"; // Label에 새로운 포인트 표시
        }



        private void DrawTicket(Graphics g, int width, int height, Color backgroundColor, string text)
        {
            // 안티앨리어싱 설정
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // 테두리 및 배경색 설정
            using (Pen borderPen = new Pen(Color.Black, 2)) // 테두리 색과 두께
            using (SolidBrush backgroundBrush = new SolidBrush(backgroundColor)) // 배경색
            {
                // 둥근 직사각형 정의
                System.Drawing.Drawing2D.GraphicsPath ticketPath = new System.Drawing.Drawing2D.GraphicsPath();
                int cornerRadius = 20; // 둥근 모서리 반지름

                // 상단 모서리
                ticketPath.AddArc(0, 0, cornerRadius, cornerRadius, 180, 90);
                ticketPath.AddArc(width - cornerRadius, 0, cornerRadius, cornerRadius, 270, 90);

                // 하단 모서리
                ticketPath.AddArc(width - cornerRadius, height - cornerRadius, cornerRadius, cornerRadius, 0, 90);
                ticketPath.AddArc(0, height - cornerRadius, cornerRadius, cornerRadius, 90, 90);
                ticketPath.CloseFigure();

                // 티켓 배경 및 테두리 그리기
                g.FillPath(backgroundBrush, ticketPath);
                g.DrawPath(borderPen, ticketPath);
            }

            // 티켓 텍스트 추가
            using (Font textFont = new Font("Arial", 16, FontStyle.Bold))
            using (Brush textBrush = new SolidBrush(Color.Black))
            {
                SizeF textSize = g.MeasureString(text, textFont);
                float textX = (width - textSize.Width) / 2;
                float textY = (height - textSize.Height) / 2;

                g.DrawString(text, textFont, textBrush, textX, textY);
            }

            // 구멍(펀치 디자인) 추가
            using (Brush holeBrush = new SolidBrush(Color.White))
            {
                int holeRadius = 10;
                g.FillEllipse(holeBrush, new Rectangle(10, height / 2 - holeRadius, holeRadius * 2, holeRadius * 2));
                g.FillEllipse(holeBrush, new Rectangle(width - 30, height / 2 - holeRadius, holeRadius * 2, holeRadius * 2));
            }
        }
        private void panel_easy_Paint(object sender, PaintEventArgs e)
        {
            DrawTicket(e.Graphics, panel_easy.Width, panel_easy.Height, Color.LightSalmon, "Easy Mode");
            
        }

        private void panel_medium_Paint(object sender, PaintEventArgs e)
        {
            DrawTicket(e.Graphics, panel_medium.Width, panel_medium.Height, Color.LightBlue, "Medium Mode");
           
        }

        private void panel_hard_Paint(object sender, PaintEventArgs e)
        {
            DrawTicket(e.Graphics, panel_hard.Width, panel_hard.Height, Color.LightCoral, "Hard Mode");
        }

        private void panel_chaos_Paint(object sender, PaintEventArgs e)
        {
            DrawTicket(e.Graphics, panel_chaos.Width, panel_chaos.Height, Color.LightGreen, "Chaos Mode");
        }

        private void panel_easy_Click(object sender, EventArgs e)
        {
            // Easy 난이도 선택 시, "Easy" 문자열을 인자로 전달하여 SeatConcert 호출
            SeatConcert seatConcert = new SeatConcert("Easy");
            seatConcert.ShowDialog();
        }

        private void panel_medium_Click(object sender, EventArgs e)
        {
            // Medium 난이도 선택 시, 포인트가 부족하면 경고, 충분하면 Medium 모드 실행
            if (UserData.UserPoints >= 20000)
            {
                SeatConcert seatConcert = new SeatConcert("Medium");
                seatConcert.ShowDialog();
            }
            else
            {
                MessageBox.Show("포인트가 부족하여 Medium 모드를 열 수 없습니다.");
            }
        }

        private void panel_hard_Click(object sender, EventArgs e)
        {
            // Hard 난이도 선택 시, 포인트가 부족하면 경고, 충분하면 Hard 모드 실행
            if (UserData.UserPoints >= 35000)
            {
                SeatConcert seatConcert = new SeatConcert("Hard");
                seatConcert.ShowDialog();
            }
            else
            {
                MessageBox.Show("포인트가 부족하여 Hard 모드를 열 수 없습니다.");
            }
        }

        private void panel_chaos_Click(object sender, EventArgs e)
        {
            // Chaos 난이도 선택 시, 포인트가 부족하면 경고, 충분하면 Chaos 모드 실행
            if (UserData.UserPoints >= 70000)
            {
                SeatConcert seatConcert = new SeatConcert("Chaos");
                seatConcert.ShowDialog();
            }
            else
            {
                MessageBox.Show("포인트가 부족하여 Chaos 모드를 열 수 없습니다.");
            }
        }

        private void ExitStartScreen_Click(object sender, EventArgs e)
        {
            // 100,000 포인트 이상이 있으면 지불하고 화면 전환
            if (UserData.UserPoints >= 100000)
            {
                // 100,000 포인트 차감
                UserData.UserPoints -= 100000;
                userpoints_label.Text = $"현재 보유 포인트: {UserData.UserPoints}원";

                // 확인 메시지 표시
                MessageBox.Show("100,000 포인트를 지불하셨습니다. 게임을 종료하고 메인 화면으로 돌아갑니다.");

                // StartScreen 폼을 새로 열고 현재 폼을 숨기기
                this.Hide(); // TicketingChoice 폼 숨기기
                var startScreenForm = new START_SCREEN();
                startScreenForm.Show();  // StartScreen 폼을 열기
                         // TicketingChoice 폼이 닫힌 후 현재 폼 다시 보이기 나중에
                         // Ticketing Choice에서 exit했을때 다시 돌아가기 위한 목적임
            }
            else
            {
                MessageBox.Show("포인트가 부족합니다. 100,000 포인트가 필요합니다.");
            }
        }
    }
    
}
