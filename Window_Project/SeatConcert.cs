using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;




namespace Window_Project
{
    public partial class SeatConcert : Form
    {
        private Timer seatTimer;
        private Timer countdownTimer;
        private Random random = new Random();
        public int totalSeats = 30; // public으로 변경
        public List<Button> seatButtons = new List<Button>(); // public으로 변경
        public int availableSeats = 30; // public으로 변경
        private int countdown = 3;
        private bool isCountdownActive = true;
        private int userSelectedTickets = 0;
        private string difficulty; // 난이도

        public static event EventHandler MediumModeUnlocked;
        public static event EventHandler HardModeUnlocked;
        public static event EventHandler ChaosModeUnlocked;



        public SeatConcert(string selectedDifficulty)
        {
            InitializeComponent();
            difficulty = selectedDifficulty;

            Console.WriteLine($"난이도: {difficulty}"); // 디버깅용 로그 추가
            InitializeSeats();
            StartCountdown();

            userpoints_label.Text = $"현재 보유 포인트: {UserData.UserPoints}원";
        }

        private void StartCountdown()
        {
            countdownTimer = new Timer();
            countdownTimer.Interval = 1000;
            countdownTimer.Tick += Countdown_Tick;
            countdownTimer.Start();

            // 카운트다운 시작 시 모든 좌석 비활성화
            DisableSeatButtons();
        }

        private void Countdown_Tick(object sender, EventArgs e)
        {
            countdown--;
            this.Invalidate();

            if (countdown == 0)
            {
                countdownTimer.Stop();
                isCountdownActive = false;
                this.Invalidate();
                MessageBox.Show("좌석 점유 시작");
                StartSeatTimer();

                // 카운트다운 끝나면 좌석 활성화
                EnableSeatButtons();
            }
        }

        private void EnableSeatButtons()
        {
            // 카운트다운이 끝나면 좌석 버튼을 활성화
            foreach (var button in seatButtons)
            {
                button.Enabled = true;
            }
        }
        private void DisableSeatButtons()
        {
            // 카운트다운 중에는 좌석 버튼을 비활성화
            foreach (var button in seatButtons)
            {
                button.Enabled = false;
            }
        }

        private void InitializeSeats()
        {
            for (int i = 0; i < totalSeats; i++)
            {
                int seatPrice = GetSeatPrice(); // 난이도에 따른 가격 계산

                Button seatButton = new Button
                {
                    Text = $"좌석 {i + 1}",
                    Size = new Size(100, 50),
                    Location = new Point(10 + (i % 5) * 110, 10 + (i / 5) * 60),
                    BackColor = Color.LightGreen,
                    Tag = seatPrice // 정확한 가격 저장
                };

                Console.WriteLine($"좌석 {i + 1} 가격: {seatPrice}"); // 로그로 확인

                seatButton.Click += SeatButton_Click;
                seatButtons.Add(seatButton);
                this.Controls.Add(seatButton);
            }
        }

        private int GetSeatPrice()
        {
            if (difficulty == "Medium")
            {
                return 3000;
            }
            else if (difficulty == "Hard")
            {
                return 5000;
            }
            else if (difficulty == "Chaos")
            {
                return 10000;
            }
            else if (difficulty == "Easy")
            {
                return 2000;
            }
            else
            {
                return 2000; // 기본값
            }
        }

        private int GetSeatTimerInterval()
        {
            if (difficulty == "Chaos") return 30;
            else if (difficulty == "Hard") return 70;
            else if (difficulty == "Medium") return 100;
            else return 200;
        }

        private void StartSeatTimer()
        {
            seatTimer = new Timer();
            seatTimer.Interval = GetSeatTimerInterval();
            seatTimer.Tick += delegate { ChangeSeatColors(); };
            seatTimer.Start();
        }

        private void ChangeSeatColors()
        {
            if (availableSeats > 0)
            {
                int seatIndex = random.Next(totalSeats);

                if (seatButtons[seatIndex].BackColor != Color.Red)
                {
                    seatButtons[seatIndex].BackColor = Color.Red;
                    seatButtons[seatIndex].Text = "판매됨";
                    availableSeats--;
                }
            }

            if (availableSeats == 0)
            {

                seatTimer.Stop();
                RefundPoints(); // 모든 좌석 판매 후 환불 처리
            }
        }

        private void SeatButton_Click(object sender, EventArgs e)
        {
            // 좌석이 클릭되었을 때 이벤트 핸들러
            Button clickedButton = sender as Button;

            if (clickedButton.BackColor == Color.Red)
            {
                MessageBox.Show("이미 판매된 좌석입니다.");
                return;
            }

            // 좌석의 가격을 가져오기 위해 Tag를 사용
            int seatPrice = (int)clickedButton.Tag;

            // 디버깅 로그 추가: 콘솔에 좌석 가격 출력
            Console.WriteLine($"좌석 가격: {seatPrice}");

            // 유저 포인트가 충분한지 확인
            if (UserData.UserPoints >= seatPrice)
            {
                UserData.UserPoints -= seatPrice; // 좌석 가격만큼 포인트 차감
                userpoints_label.Text = $"현재 보유 포인트: {UserData.UserPoints}원";

                clickedButton.BackColor = Color.Red; // 좌석 상태 변경
                clickedButton.Text = "판매됨";

                userSelectedTickets++; // 구매한 티켓 수 증가

                MessageBox.Show("결제가 성공적으로 처리되었습니다!");
            }
            else
            {
                MessageBox.Show("포인트가 부족하여 결제할 수 없습니다.");
                RefundPoints(); // 잔여 티켓 환불
                this.Close();   // 폼 종료
            }
        }

        private void RefundPoints()
        {
            if (userSelectedTickets > 0)
            {
                int refundAmount = userSelectedTickets * GetSeatPrice() * 2; // 환급 금액 계산
                UserData.UserPoints += refundAmount;
                userpoints_label.Text = $"현재 보유 포인트: {UserData.UserPoints}원";
                MessageBox.Show($"성공적으로 구매한 {userSelectedTickets}장의 티켓에 대해 총 {refundAmount}원을 돌려드렸습니다.");

                // 각 난이도별 목표 금액을 달성한 경우에만 해당 난이도 이벤트를 발생시킴


            }
            else
            {
                int penaltypoint = GetSeatPrice() * 2;
                UserData.UserPoints -= penaltypoint;
                string message = $"구매한 티켓이 없어 환불이 진행되지 않았습니다.\n" +
                  $"참여에 실패하여 {penaltypoint} 포인트를 차감합니다.";
                MessageBox.Show(message);       
                this.Close();
            }
        }

        private void SettleButton_Click(object sender, EventArgs e)
        {
            if (userSelectedTickets > 0)
            {

                int refundAmount = userSelectedTickets * GetSeatPrice() * 2; // 환급 금액 계산
                UserData.UserPoints += refundAmount;
                userpoints_label.Text = $"현재 보유 포인트: {UserData.UserPoints}원";

                MessageBox.Show($"구매한 {userSelectedTickets}장의 티켓에 대해 총 {refundAmount}원이 환급되었습니다.");
                this.Close(); // 폼 종료
            }
        }


        public void CheckModeUnlock()
        {
            // 각 난이도별 포인트 조건 체크
            if (difficulty == "Easy")
            {
                if (UserData.UserPoints >= 20000)
                {
                    MediumModeUnlocked?.Invoke(this, EventArgs.Empty); // Medium 모드 잠금 해제
                }
            }
            else if (difficulty == "Medium")
            {
                if (UserData.UserPoints >= 35000)
                {
                    HardModeUnlocked?.Invoke(this, EventArgs.Empty); // Hard 모드 잠금 해제
                }
            }
            else if (difficulty == "Hard")
            {
                if (UserData.UserPoints >= 70000)
                {
                    ChaosModeUnlocked?.Invoke(this, EventArgs.Empty); // Chaos 모드 잠금 해제
                }
            }
            else if (difficulty == "Chaos")
            {
                if (UserData.UserPoints >= 60000)
                {
                    MessageBox.Show("축하합니다! Chaos 모드를 완료했습니다.");
                    Application.Exit(); // 게임 종료
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (isCountdownActive && countdown > 0)
            {
                Graphics g = e.Graphics;
                string text = countdown.ToString();
                Font font = new Font("Arial", 48, FontStyle.Bold);
                SizeF textSize = g.MeasureString(text, font);
                float textX = this.ClientSize.Width - textSize.Width - 10;
                float textY = 10;
                g.DrawString(text, font, Brushes.Black, textX, textY);
            }
        }
        private void SeatConcert_Paint(object sender, PaintEventArgs e)
        {

            // 그라디언트 색상
            LinearGradientBrush gradientBrush = new LinearGradientBrush(this.ClientRectangle, Color.LightBlue, Color.White, 45f);
            e.Graphics.FillRectangle(gradientBrush, this.ClientRectangle);

        }
    }


}

     


