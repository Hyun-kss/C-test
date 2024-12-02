using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Window_Project
{
    public partial class START_SCREEN : Form
    {
        public START_SCREEN()
        {
            InitializeComponent();
        }

        private void start_button_Click(object sender, EventArgs e)
        {
            // UserData에서 초기 포인트 값을 설정
            UserData.UserPoints = 10000; // 10000원으로 설정


            
            TicketingChoice ticketingChoice = new TicketingChoice();
           
            this.Hide(); // 현재 폼 숨기기
            ticketingChoice.ShowDialog(); // TicketingChoice 폼을 모달로 열기
                         
        }

        private void exit_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void START_SCREEN_Load(object sender, EventArgs e)
        {
            // 이미지 파일 경로 설정
            string imagePath = "C:\\Users\\82105\\OneDrive\\Desktop\\컴공자료\\윈도우 프로그래밍\\main_screen.png";
                
            // 이미지 동적으로 로드
            if (System.IO.File.Exists(imagePath))
            {
                this.BackgroundImage = Image.FromFile(imagePath);
                this.BackgroundImageLayout = ImageLayout.Stretch; // 폼 크기에 맞게 조정
            }
            else
            {
                MessageBox.Show("이미지 파일을 찾을 수 없습니다.");
            }
        }
    }
}
