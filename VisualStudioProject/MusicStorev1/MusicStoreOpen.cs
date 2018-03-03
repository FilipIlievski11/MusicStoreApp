using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace MusicStorev1
{
    public partial class MusicStoreOpen : Form
    {
        private string doc, path;
        private string[] newurl;
        public static string uuu="";
        public MusicStoreOpen(string sendtext)
        {
            InitializeComponent();
            uuu = sendtext;
            OneStars.SizeMode = PictureBoxSizeMode.StretchImage;
            if (uuu.Equals("Admin"))
            {
                Adminbtn.Visible = true;
            }
        }
      
        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
        // AdminPanel Otvori
        private void Adminbtn_Click(object sender, EventArgs e)
        {
            MySongsList.Visible = false;
            listGenres.Visible = false;
            MyProfilePanel.Visible = false;
            AdminPanel.Visible = true;
            AlbumList.Visible = false;
            ArtistList.Visible = false;
        }

        // MyProfile Otvori
        private void btnProfile_Click(object sender, EventArgs e)
        {
            ArtistList.Visible = false;
            MySongsList.Visible = false;
            ListPanel.Visible = false;
            listGenres.Visible = false;
            MyProfilePanel.Visible = true;
            AlbumList.Visible = false;
            ArtistList.Visible = false;
            NpgsqlConnection conn1 = new NpgsqlConnection("Server=localhost;User Id=Filip;" + "Password=123;Database=MusicStoreOfficial;");
            conn1.Open();
            NpgsqlCommand cmd1 = new NpgsqlCommand("select * from useracc where username='"+uuu+"'", conn1);
            NpgsqlDataReader dr = cmd1.ExecuteReader();
            dr.Read();
            accusername.Text = dr[1].ToString();
            accfirstname.Text= dr[3].ToString();
            accsecondname.Text = dr[4].ToString();
            if (!string.IsNullOrWhiteSpace(dr[6].ToString()))
            {
                UserURL.Image = System.Drawing.Image.FromFile(dr[6].ToString());
                UserURL.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            string drzava = dr[5].ToString();
            conn1.Close();
            conn1.Open();
            NpgsqlCommand cmd2 = new NpgsqlCommand("select * from country where countryID='" + drzava + "'", conn1);
            NpgsqlDataReader dr1 = cmd2.ExecuteReader();
            dr1.Read();
            acccountry.Text=dr1[1].ToString();
            conn1.Close();

            

        }

        // MyProfile Stavi Nov Pw
        private void NewPasswordBtn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(newpw.Text))
            {
                NpgsqlConnection conn1 = new NpgsqlConnection("Server=localhost;User Id=Filip;" + "Password=123;Database=MusicStoreOfficial;");
                conn1.Open();
                NpgsqlCommand cmd1=new NpgsqlCommand("UPDATE useracc SET userpassword = '" + newpw.Text + "' WHERE username = '" + uuu + "';",conn1);
                cmd1.ExecuteNonQuery();
                conn1.Close();
                done.Visible = true;
                enternewpassword.Visible = false;
            }
            else
            {
                done.Visible = false;
                enternewpassword.Visible = true;
            }

        }

        // MyProfile stavi slika
        private void OpenBtn_Click(object sender, EventArgs e)
        {
            string path;
            OpenFileDialog open = new OpenFileDialog();
            open.Multiselect = false;
            open.Filter = "All Graphics Types | *.bmp; *.jpg; *.jpeg; *.png; *.tif; *.tiff | "
                          + "BMP|*.bmp|GIF|*.gif|JPG|*.jpg;*.jpeg|PNG|*.png|TIFF|*.tif;*.tiff|"
                          + "Zip Files|*.zip;*.rar";
            if (open.ShowDialog() == DialogResult.OK)
            {
                UserURL.Image = System.Drawing.Image.FromFile(open.FileName);
                UserURL.SizeMode = PictureBoxSizeMode.StretchImage;
                path = open.FileName;
                NpgsqlConnection conn1 = new NpgsqlConnection("Server=localhost;User Id=Filip;" + "Password=123;Database=MusicStoreOfficial;");
                conn1.Open();
                NpgsqlCommand cmd1 = new NpgsqlCommand("UPDATE useracc SET userurl = '" + path + "' WHERE username = '" + uuu + "';", conn1);
                cmd1.ExecuteNonQuery();
                conn1.Close();
                Openright.Visible = false;
            }
            else
            {
                Openright.Visible = true;
            }
            
        }

        // Genres Otvori
        private void btnGenres_Click(object sender, EventArgs e)
        {
            listGenres.Visible = true;
            MyProfilePanel.Visible = false;
            ListPanel.Visible = false;
            MySongsList.Visible = false;
            ArtistList.Visible = false;
            AlbumList.Visible = false;
            ArtistList.Visible = false;
        }
       
        // AdminPanel Stavi pesna vo bazata
        private void AddSongsToDatabase_Click(object sender, EventArgs e)
        {
            MySongsList.Visible = false;
            OpenFileDialog open = new OpenFileDialog();
            open.Multiselect = false;
            open.Filter = "Mp3 Files|*.mp3|Avi Files|*.avi|Wav Files|*.wav";
            if (open.ShowDialog() == DialogResult.OK)
            {
                doc = open.SafeFileName; // iminjata
                path = open.FileName;  // patishtata
                NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;User Id=Filip;" + "Password=123;Database=MusicStoreOfficial;");
                conn.Open();
                NpgsqlCommand com = new NpgsqlCommand("insert into song(songname, songdate, songlength, songprice, categoriesid, albumid, songurl) values('"+doc+"', '"+godina.Text+"', '"+Vreme.Text+"', '5', '"+int.Parse(Kategorija.Text)+ "', '3', '" + path+"')",conn);
                com.ExecuteNonQuery();
                conn.Close();
            }
        }


        // AllSongs panel kopce gi otvara site pesni vo bazata
        private void btnAllSongs_Click(object sender, EventArgs e)
        {
            AlbumList.Visible = false;
            ArtistList.Visible = false;
            ArtistList.Visible = false;
            ListPanel.Items.Clear();
            ListPanel.Visible = true;
            listGenres.Visible = false;
            MyProfilePanel.Visible = false;
            MySongsList.Visible = false;
            NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;User Id=Filip;" + "Password=123;Database=MusicStoreOfficial;");
            conn.Open();
            NpgsqlCommand com = new NpgsqlCommand("select * from song order by songname", conn);
            NpgsqlDataReader dr = com.ExecuteReader();
           
            while (dr.Read())
            {
                ListPanel.Items.Add(dr[1].ToString());
            }
            conn.Close();

        }
        // KupiPesna prozorec
        private void ListPanel_SelectedIndexChanged(object sender, EventArgs e)
        {
            ArtistList.Visible = false;
            KupiPesnaKopce.Visible = false;
            PlayBttn.Visible = false;
            buySongPanel.Visible = true;
            ImeNaPesna.Text = ListPanel.SelectedItem.ToString();
            NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;User Id=Filip;" + "Password=123;Database=MusicStoreOfficial;");
            conn.Open();
            NpgsqlCommand com = new NpgsqlCommand("select s.songname,s.songdate,s.songlength,s.songprice, a.artistname from song s, artist a, arecords where s.songid = arecords.songid and arecords.artistid = a.artistid and s.songname ='" + ListPanel.SelectedItem.ToString() +"'", conn);
            NpgsqlDataReader dr = com.ExecuteReader();
            dr.Read();
            ImeNaArtist.Text = dr[4].ToString();
            GodinaNaPesna.Text = dr[1].ToString();
            CenaNaPesna.Text = dr[3].ToString();
            VremeNaPesna.Text = dr[2].ToString();
            conn.Close();
            ImeNaPesna.Text = ListPanel.SelectedItem.ToString();
            NpgsqlConnection conn2 = new NpgsqlConnection("Server=localhost;User Id=Filip;" + "Password=123;Database=MusicStoreOfficial;");  
            conn2.Open();
            NpgsqlCommand com2 = new NpgsqlCommand("select round(avg(r.stars),2) from song s,rating r where s.songid=r.songid and s.songname='" + ListPanel.SelectedItem.ToString() + "' group by (songname)", conn2);
            NpgsqlDataReader dr2 = com2.ExecuteReader();
            dr2.Read();
            if (dr2.HasRows)
            {
                AverageRating.Text = dr2[0].ToString();
            }
            else
            {
                AverageRating.Text = "Not rated";
            }
            conn2.Close();
            NpgsqlConnection conn4 = new NpgsqlConnection("Server=localhost;User Id=Filip;" + "Password=123;Database=MusicStoreOfficial;");
            conn4.Open();
            NpgsqlCommand com4 = new NpgsqlCommand("select countryname from country c, useracc u where c.countryid = u.countryid and u.username = '"+uuu+"'", conn4);
            NpgsqlDataReader dr4 = com4.ExecuteReader();
            dr4.Read();
            NpgsqlConnection conn3 = new NpgsqlConnection("Server=localhost;User Id=Filip;" + "Password=123;Database=MusicStoreOfficial;");
            conn3.Open();
            NpgsqlCommand com3 = new NpgsqlCommand("select round(avg(r.stars),2) from country c join useracc u on c.countryid=u.countryid join rating r on r.userid=u.userid join song s on r.songid=s.songid where c.countryname='"+dr4[0].ToString()+"' group by c.countryname", conn3);
            NpgsqlDataReader dr3 = com3.ExecuteReader();
            dr3.Read();
            if(dr3.HasRows)
            {
                RatingByCountry.Text = dr3[0].ToString();
            }
            else
            {
                RatingByCountry.Text = "Not rated";
            }
            conn3.Close();
            conn4.Close();
            NpgsqlConnection conn10 = new NpgsqlConnection("Server=localhost;User Id=Filip;" + "Password=123;Database=MusicStoreOfficial;");
            conn10.Open();
            NpgsqlCommand com10 = new NpgsqlCommand("select s.songname from song s, useracc u, boughtsong bs where s.songid = bs.songid and u.userid = bs.userid and u.username='"+uuu+"' and s.songname='" + ListPanel.SelectedItem.ToString() + "'", conn10);
            NpgsqlDataReader dr10 = com10.ExecuteReader();
            dr10.Read();
            if (dr10.HasRows)
            {
                PlayBttn.Visible = true;
            }
            else
            {
                KupiPesnaKopce.Visible = true;
            }
        }
        // KupiPesna Close
        private void button1_Click(object sender, EventArgs e)
        {
            buySongPanel.Visible = false;
        }
        // KupiPesna Buy kopce
        private void KupiPesnaKopce_Click(object sender, EventArgs e)
        {
            buySongPanel.Visible = false;
            // id na korisnikot
            NpgsqlConnection conn1 = new NpgsqlConnection("Server=localhost;User Id=Filip;" + "Password=123;Database=MusicStoreOfficial;");
            conn1.Open();
            NpgsqlCommand com1 = new NpgsqlCommand("select userID from useracc where username='"+uuu+"' ", conn1);
            NpgsqlDataReader dr1 = com1.ExecuteReader();
            dr1.Read();
            // id na pesnata
            NpgsqlConnection conn2 = new NpgsqlConnection("Server=localhost;User Id=Filip;" + "Password=123;Database=MusicStoreOfficial;");
            conn2.Open();
            NpgsqlCommand com2 = new NpgsqlCommand("select songID from song where songname='"+ ListPanel.SelectedItem.ToString() +"'", conn2);
            NpgsqlDataReader dr2 = com2.ExecuteReader();
            dr2.Read();
            // vnesi kupena pesna
            NpgsqlConnection conn3 = new NpgsqlConnection("Server=localhost;User Id=Filip;" + "Password=123;Database=MusicStoreOfficial;");
            conn3.Open();
            NpgsqlCommand com3 = new NpgsqlCommand("insert into boughtsong(songID,userID) values('"+dr2[0]+"','"+dr1[0]+"')", conn3);
            com3.ExecuteNonQuery();
            conn1.Close();
            conn2.Close();
            conn3.Close();
        }

        // Country Genre lista
        private void btnCountry_Click(object sender, EventArgs e)
        {
            AlbumList.Visible = false;
            ArtistList.Visible = false;
            ListPanel.Items.Clear();
            ListPanel.Visible = true;
            listGenres.Visible = false;
            MyProfilePanel.Visible = false;
            NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;User Id=Filip;" + "Password=123;Database=MusicStoreOfficial;");
            conn.Open();
            NpgsqlCommand com = new NpgsqlCommand("select * from song where categoriesid='1' order by songname", conn);
            NpgsqlDataReader dr = com.ExecuteReader();
            while (dr.Read())
            {
                ListPanel.Items.Add(dr[1].ToString());
            }
            conn.Close();

        }

        // Rock Genre lista
        private void btnRock_Click(object sender, EventArgs e)
        {
            AlbumList.Visible = false;
            ArtistList.Visible = false;
            ListPanel.Items.Clear();
            ListPanel.Visible = true;
            listGenres.Visible = false;
            MyProfilePanel.Visible = false;
            NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;User Id=Filip;" + "Password=123;Database=MusicStoreOfficial;");
            conn.Open();
            NpgsqlCommand com = new NpgsqlCommand("select * from song where categoriesid='2' order by songname", conn);
            NpgsqlDataReader dr = com.ExecuteReader();
            while (dr.Read())
            {
                ListPanel.Items.Add(dr[1].ToString());
            }
            conn.Close();
        }

        // Punk Genre lista
        private void btnPunk_Click(object sender, EventArgs e)
        {
            AlbumList.Visible = false;
            ArtistList.Visible = false;
            ListPanel.Items.Clear();
            ListPanel.Visible = true;
            listGenres.Visible = false;
            MyProfilePanel.Visible = false;
            NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;User Id=Filip;" + "Password=123;Database=MusicStoreOfficial;");
            conn.Open();
            NpgsqlCommand com = new NpgsqlCommand("select * from song where categoriesid='3' order by songname", conn);
            NpgsqlDataReader dr = com.ExecuteReader();
            while (dr.Read())
            {
                ListPanel.Items.Add(dr[1].ToString());
            }
            conn.Close();
        }

        // Metal Genre lista
        private void btnMetal_Click(object sender, EventArgs e)
        {
            AlbumList.Visible = false;
            ArtistList.Visible = false;
            ListPanel.Items.Clear();
            ListPanel.Visible = true;
            listGenres.Visible = false;
            MyProfilePanel.Visible = false;
            NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;User Id=Filip;" + "Password=123;Database=MusicStoreOfficial;");
            conn.Open();
            NpgsqlCommand com = new NpgsqlCommand("select * from song where categoriesid='4' order by songname", conn);
            NpgsqlDataReader dr = com.ExecuteReader();
            while (dr.Read())
            {
                ListPanel.Items.Add(dr[1].ToString());
            }
            conn.Close();
        }

        // Pop Genre lista
        private void btnPop_Click(object sender, EventArgs e)
        {
            AlbumList.Visible = false;
            ArtistList.Visible = false;
            ListPanel.Items.Clear();
            ListPanel.Visible = true;
            listGenres.Visible = false;
            MyProfilePanel.Visible = false;
            NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;User Id=Filip;" + "Password=123;Database=MusicStoreOfficial;");
            conn.Open();
            NpgsqlCommand com = new NpgsqlCommand("select * from song where categoriesid='5' order by songname", conn);
            NpgsqlDataReader dr = com.ExecuteReader();
            while (dr.Read())
            {
                ListPanel.Items.Add(dr[1].ToString());
            }
        }

        // Trance Genre lista
        private void btnTrance_Click(object sender, EventArgs e)
        {
            AlbumList.Visible = false;
            ArtistList.Visible = false;
            ListPanel.Items.Clear();
            ListPanel.Visible = true;
            listGenres.Visible = false;
            MyProfilePanel.Visible = false;
            NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;User Id=Filip;" + "Password=123;Database=MusicStoreOfficial;");
            conn.Open();
            NpgsqlCommand com = new NpgsqlCommand("select * from song where categoriesid='6' order by songname", conn);
            NpgsqlDataReader dr = com.ExecuteReader();
            while (dr.Read())
            {
                ListPanel.Items.Add(dr[1].ToString());
            }
            conn.Close();
        }

        // Techno Genre lista
        private void btnTechno_Click(object sender, EventArgs e)
        {
            AlbumList.Visible = false;
            ArtistList.Visible = false;
            ListPanel.Items.Clear();
            ListPanel.Visible = true;
            listGenres.Visible = false;
            MyProfilePanel.Visible = false;
            NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;User Id=Filip;" + "Password=123;Database=MusicStoreOfficial;");
            conn.Open();
            NpgsqlCommand com = new NpgsqlCommand("select * from song where categoriesid='7' order by songname", conn);
            NpgsqlDataReader dr = com.ExecuteReader();
            while (dr.Read())
            {
                ListPanel.Items.Add(dr[1].ToString());
            }
            conn.Close();
        }

        // HipHop Genre lista
        private void btnHiphop_Click(object sender, EventArgs e)
        {
            ListPanel.Items.Clear();
            ListPanel.Visible = true;
            listGenres.Visible = false;
            MyProfilePanel.Visible = false;
            AlbumList.Visible = false;
            ArtistList.Visible = false;
            NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;User Id=Filip;" + "Password=123;Database=MusicStoreOfficial;");
            conn.Open();
            NpgsqlCommand com = new NpgsqlCommand("select * from song where categoriesid='8' order by songname", conn);
            NpgsqlDataReader dr = com.ExecuteReader();
            while (dr.Read())
            {
                ListPanel.Items.Add(dr[1].ToString());
            }
            conn.Close();
        }

        // My Songs Panel otvori
        private void btnMySongs_Click(object sender, EventArgs e)
        {
            MySongsList.Items.Clear();
            ListPanel.Visible = false;
            listGenres.Visible = false;
            MyProfilePanel.Visible = false;
            MySongsList.Visible = true;
            ArtistList.Visible = false;
            AlbumList.Visible = false;
           
            // napolni ja listata
            NpgsqlConnection conn1 = new NpgsqlConnection("Server=localhost;User Id=Filip;" + "Password=123;Database=MusicStoreOfficial;");
            conn1.Open();
            NpgsqlCommand com1 = new NpgsqlCommand("select s.songname from song s, useracc u,boughtsong bs where s.songID=bs.songID and bs.userID=u.userID and u.username='"+uuu+"'", conn1);
            NpgsqlDataReader dr1 = com1.ExecuteReader();
                while (dr1.Read())
                {
                    MySongsList.Items.Add(dr1[0]);
                }
            conn1.Close();
        }
        // My songs pusti pesna
        private void MySongsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            NpgsqlConnection conn1 = new NpgsqlConnection("Server=localhost;User Id=Filip;" + "Password=123;Database=MusicStoreOfficial;");
            conn1.Open();
            NpgsqlCommand com1 = new NpgsqlCommand("select s.songurl from song s where s.songname='" + MySongsList.SelectedItem.ToString() + "'", conn1);
            NpgsqlDataReader dr1 = com1.ExecuteReader();
            dr1.Read();
            WMP.URL = dr1[0].ToString();
            conn1.Close();
        }

        //rating Edna zvezda
        private void OneStars_Click(object sender, EventArgs e)
        {
            // id na korisnikot
            NpgsqlConnection conn1 = new NpgsqlConnection("Server=localhost;User Id=Filip;" + "Password=123;Database=MusicStoreOfficial;");
            conn1.Open();
            NpgsqlCommand com1 = new NpgsqlCommand("select userID from useracc where username='" + uuu + "' ", conn1);
            NpgsqlDataReader dr1 = com1.ExecuteReader();
            dr1.Read();
            // id na pesnata
            NpgsqlConnection conn2 = new NpgsqlConnection("Server=localhost;User Id=Filip;" + "Password=123;Database=MusicStoreOfficial;");
            conn2.Open();
            NpgsqlCommand com2 = new NpgsqlCommand("select songID from song where songname='" + ListPanel.SelectedItem.ToString() + "'",conn2);
            NpgsqlDataReader dr2 = com2.ExecuteReader();
            dr2.Read();
            // proveri dali ima vekje rejtano
            // id na pesnata
            NpgsqlConnection conn4 = new NpgsqlConnection("Server=localhost;User Id=Filip;" + "Password=123;Database=MusicStoreOfficial;");
            conn4.Open();
            NpgsqlCommand com4 = new NpgsqlCommand("select * from rating where songid='" + dr2[0] + "' and userid='"+dr1[0]+"'", conn4);
            NpgsqlDataReader dr4 = com4.ExecuteReader();
            dr4.Read();
            // proveri dali ima predhodno rejtano ista pesna
            if(dr4.HasRows)
            {
                // smeni rejt na pesna
                NpgsqlConnection conn5 = new NpgsqlConnection("Server=localhost;User Id=Filip;" + "Password=123;Database=MusicStoreOfficial;");
                conn5.Open();
                NpgsqlCommand com5 = new NpgsqlCommand("UPDATE rating SET stars = '1' WHERE songid = '"+dr2[0]+"' and userid='"+dr1[0]+"';", conn5);
                com5.ExecuteNonQuery();
                conn5.Close();
                

            }       
            else { 
            // vnesi rejt na pesna
            NpgsqlConnection conn3 = new NpgsqlConnection("Server=localhost;User Id=Filip;" + "Password=123;Database=MusicStoreOfficial;");
            conn3.Open();
            NpgsqlCommand com3 = new NpgsqlCommand("insert into rating(songid,userid,stars) values('"+dr2[0]+"','"+dr1[0]+"','1')", conn3);
            com3.ExecuteNonQuery();
            conn3.Close();
               
            }
            conn1.Close();
            conn2.Close();
            conn4.Close();

        }
        //rating Dve zvezdi
        private void TwoStars_Click(object sender, EventArgs e)
        {
            // id na korisnikot
            NpgsqlConnection conn1 = new NpgsqlConnection("Server=localhost;User Id=Filip;" + "Password=123;Database=MusicStoreOfficial;");
            conn1.Open();
            NpgsqlCommand com1 = new NpgsqlCommand("select userID from useracc where username='" + uuu + "' ", conn1);
            NpgsqlDataReader dr1 = com1.ExecuteReader();
            dr1.Read();
            // id na pesnata
            NpgsqlConnection conn2 = new NpgsqlConnection("Server=localhost;User Id=Filip;" + "Password=123;Database=MusicStoreOfficial;");
            conn2.Open();
            NpgsqlCommand com2 = new NpgsqlCommand("select songID from song where songname='" + ListPanel.SelectedItem.ToString() + "'", conn2);
            NpgsqlDataReader dr2 = com2.ExecuteReader();
            dr2.Read();
            // proveri dali ima vekje rejtano
            // id na pesnata
            NpgsqlConnection conn4 = new NpgsqlConnection("Server=localhost;User Id=Filip;" + "Password=123;Database=MusicStoreOfficial;");
            conn4.Open();
            NpgsqlCommand com4 = new NpgsqlCommand("select * from rating where songid='" + dr2[0] + "' and userid='" + dr1[0] + "'", conn4);
            NpgsqlDataReader dr4 = com4.ExecuteReader();
            dr4.Read();
            // proveri dali ima predhodno rejtano ista pesna
            if (dr4.HasRows)
            {
                // smeni rejt na pesna
                NpgsqlConnection conn5 = new NpgsqlConnection("Server=localhost;User Id=Filip;" + "Password=123;Database=MusicStoreOfficial;");
                conn5.Open();
                NpgsqlCommand com5 = new NpgsqlCommand("UPDATE rating SET stars = '2' WHERE songid = '" + dr2[0] + "' and userid='" + dr1[0] + "';", conn5);
                com5.ExecuteNonQuery();
                conn5.Close();


            }
            else
            {
                // vnesi rejt na pesna
                NpgsqlConnection conn3 = new NpgsqlConnection("Server=localhost;User Id=Filip;" + "Password=123;Database=MusicStoreOfficial;");
                conn3.Open();
                NpgsqlCommand com3 = new NpgsqlCommand("insert into rating(songid,userid,stars) values('" + dr2[0] + "','" + dr1[0] + "','2')", conn3);
                com3.ExecuteNonQuery();
                conn3.Close();

            }
            conn1.Close();
            conn2.Close();
            conn4.Close();
        }
        //rating Tri zvezdi
        private void ThreeStars_Click(object sender, EventArgs e)
        {
            // id na korisnikot
            NpgsqlConnection conn1 = new NpgsqlConnection("Server=localhost;User Id=Filip;" + "Password=123;Database=MusicStoreOfficial;");
            conn1.Open();
            NpgsqlCommand com1 = new NpgsqlCommand("select userID from useracc where username='" + uuu + "' ", conn1);
            NpgsqlDataReader dr1 = com1.ExecuteReader();
            dr1.Read();
            // id na pesnata
            NpgsqlConnection conn2 = new NpgsqlConnection("Server=localhost;User Id=Filip;" + "Password=123;Database=MusicStoreOfficial;");
            conn2.Open();
            NpgsqlCommand com2 = new NpgsqlCommand("select songID from song where songname='" + ListPanel.SelectedItem.ToString() + "'", conn2);
            NpgsqlDataReader dr2 = com2.ExecuteReader();
            dr2.Read();
            // proveri dali ima vekje rejtano
            // id na pesnata
            NpgsqlConnection conn4 = new NpgsqlConnection("Server=localhost;User Id=Filip;" + "Password=123;Database=MusicStoreOfficial;");
            conn4.Open();
            NpgsqlCommand com4 = new NpgsqlCommand("select * from rating where songid='" + dr2[0] + "' and userid='" + dr1[0] + "'", conn4);
            NpgsqlDataReader dr4 = com4.ExecuteReader();
            dr4.Read();
            // proveri dali ima predhodno rejtano ista pesna
            if (dr4.HasRows)
            {
                // smeni rejt na pesna
                NpgsqlConnection conn5 = new NpgsqlConnection("Server=localhost;User Id=Filip;" + "Password=123;Database=MusicStoreOfficial;");
                conn5.Open();
                NpgsqlCommand com5 = new NpgsqlCommand("UPDATE rating SET stars = '3' WHERE songid = '" + dr2[0] + "' and userid='" + dr1[0] + "';", conn5);
                com5.ExecuteNonQuery();
                conn5.Close();


            }
            else
            {
                // vnesi rejt na pesna
                NpgsqlConnection conn3 = new NpgsqlConnection("Server=localhost;User Id=Filip;" + "Password=123;Database=MusicStoreOfficial;");
                conn3.Open();
                NpgsqlCommand com3 = new NpgsqlCommand("insert into rating(songid,userid,stars) values('" + dr2[0] + "','" + dr1[0] + "','3')", conn3);
                com3.ExecuteNonQuery();
                conn3.Close();

            }
            conn1.Close();
            conn2.Close();
            conn4.Close();
        }
        //rating Cetiri zvezdi
        private void FourStars_Click(object sender, EventArgs e)
        {
            // id na korisnikot
            NpgsqlConnection conn1 = new NpgsqlConnection("Server=localhost;User Id=Filip;" + "Password=123;Database=MusicStoreOfficial;");
            conn1.Open();
            NpgsqlCommand com1 = new NpgsqlCommand("select userID from useracc where username='" + uuu + "' ", conn1);
            NpgsqlDataReader dr1 = com1.ExecuteReader();
            dr1.Read();
            // id na pesnata
            NpgsqlConnection conn2 = new NpgsqlConnection("Server=localhost;User Id=Filip;" + "Password=123;Database=MusicStoreOfficial;");
            conn2.Open();
            NpgsqlCommand com2 = new NpgsqlCommand("select songID from song where songname='" + ListPanel.SelectedItem.ToString() + "'", conn2);
            NpgsqlDataReader dr2 = com2.ExecuteReader();
            dr2.Read();
            // proveri dali ima vekje rejtano
            // id na pesnata
            NpgsqlConnection conn4 = new NpgsqlConnection("Server=localhost;User Id=Filip;" + "Password=123;Database=MusicStoreOfficial;");
            conn4.Open();
            NpgsqlCommand com4 = new NpgsqlCommand("select * from rating where songid='" + dr2[0] + "' and userid='" + dr1[0] + "'", conn4);
            NpgsqlDataReader dr4 = com4.ExecuteReader();
            dr4.Read();
            // proveri dali ima predhodno rejtano ista pesna
            if (dr4.HasRows)
            {
                // smeni rejt na pesna
                NpgsqlConnection conn5 = new NpgsqlConnection("Server=localhost;User Id=Filip;" + "Password=123;Database=MusicStoreOfficial;");
                conn5.Open();
                NpgsqlCommand com5 = new NpgsqlCommand("UPDATE rating SET stars = '4' WHERE songid = '" + dr2[0] + "' and userid='" + dr1[0] + "';", conn5);
                com5.ExecuteNonQuery();
                conn5.Close();


            }
            else
            {
                // vnesi rejt na pesna
                NpgsqlConnection conn3 = new NpgsqlConnection("Server=localhost;User Id=Filip;" + "Password=123;Database=MusicStoreOfficial;");
                conn3.Open();
                NpgsqlCommand com3 = new NpgsqlCommand("insert into rating(songid,userid,stars) values('" + dr2[0] + "','" + dr1[0] + "','4')", conn3);
                com3.ExecuteNonQuery();
                conn3.Close();

            }
            conn1.Close();
            conn2.Close();
            conn4.Close();
        }
        //rating Pet zvezdi
        private void FiveStars_Click(object sender, EventArgs e)
        {
            // id na korisnikot
            NpgsqlConnection conn1 = new NpgsqlConnection("Server=localhost;User Id=Filip;" + "Password=123;Database=MusicStoreOfficial;");
            conn1.Open();
            NpgsqlCommand com1 = new NpgsqlCommand("select userID from useracc where username='" + uuu + "' ", conn1);
            NpgsqlDataReader dr1 = com1.ExecuteReader();
            dr1.Read();
            // id na pesnata
            NpgsqlConnection conn2 = new NpgsqlConnection("Server=localhost;User Id=Filip;" + "Password=123;Database=MusicStoreOfficial;");
            conn2.Open();
            NpgsqlCommand com2 = new NpgsqlCommand("select songID from song where songname='" + ListPanel.SelectedItem.ToString() + "'", conn2);
            NpgsqlDataReader dr2 = com2.ExecuteReader();
            dr2.Read();
            // proveri dali ima vekje rejtano
            // id na pesnata
            NpgsqlConnection conn4 = new NpgsqlConnection("Server=localhost;User Id=Filip;" + "Password=123;Database=MusicStoreOfficial;");
            conn4.Open();
            NpgsqlCommand com4 = new NpgsqlCommand("select * from rating where songid='" + dr2[0] + "' and userid='" + dr1[0] + "'", conn4);
            NpgsqlDataReader dr4 = com4.ExecuteReader();
            dr4.Read();
            // proveri dali ima predhodno rejtano ista pesna
            if (dr4.HasRows)
            {
                // smeni rejt na pesna
                NpgsqlConnection conn5 = new NpgsqlConnection("Server=localhost;User Id=Filip;" + "Password=123;Database=MusicStoreOfficial;");
                conn5.Open();
                NpgsqlCommand com5 = new NpgsqlCommand("UPDATE rating SET stars = '5' WHERE songid = '" + dr2[0] + "' and userid='" + dr1[0] + "';", conn5);
                com5.ExecuteNonQuery();
                conn5.Close();


            }
            else
            {
                // vnesi rejt na pesna
                NpgsqlConnection conn3 = new NpgsqlConnection("Server=localhost;User Id=Filip;" + "Password=123;Database=MusicStoreOfficial;");
                conn3.Open();
                NpgsqlCommand com3 = new NpgsqlCommand("insert into rating(songid,userid,stars) values('" + dr2[0] + "','" + dr1[0] + "','5')", conn3);
                com3.ExecuteNonQuery();
                conn3.Close();

            }
            conn1.Close();
            conn2.Close();
            conn4.Close();
        }
        // Play od buy prozorec
        private void PlayBttn_Click(object sender, EventArgs e)
        {
            buySongPanel.Visible = false;
            NpgsqlConnection conn1 = new NpgsqlConnection("Server=localhost;User Id=Filip;" + "Password=123;Database=MusicStoreOfficial;");
            conn1.Open();
            NpgsqlCommand com1 = new NpgsqlCommand("select s.songurl from song s where s.songname='" + ListPanel.SelectedItem.ToString() + "'", conn1);
            NpgsqlDataReader dr1 = com1.ExecuteReader();
            dr1.Read();
            WMP.URL = dr1[0].ToString();
            conn1.Close();
        }


        // Lista od Artisti otvori
        private void btnArtists_Click(object sender, EventArgs e)
        {
            ArtistList.Visible = true;
            buySongPanel.Visible = false;
            ListPanel.Visible = false;
            listGenres.Visible = false;
            MyProfilePanel.Visible = false;
            MySongsList.Visible = false;
            AlbumList.Visible = false;
            NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;User Id=Filip;" + "Password=123;Database=MusicStoreOfficial;");
            conn.Open();
            NpgsqlCommand com2 = new NpgsqlCommand("select * from artist", conn);
            NpgsqlDataReader dr2 = com2.ExecuteReader();
            dr2.Read();
            while (dr2.Read())
            {
                ArtistList.Items.Add(dr2[1].ToString());
            }
            conn.Close();
        }
        // Klikni na Artist
        private void ArtistList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListPanel.Items.Clear();
            ArtistList.Visible = false;
            ListPanel.Visible = true;
            listGenres.Visible = false;
            MyProfilePanel.Visible = false;
            NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;User Id=Filip;" + "Password=123;Database=MusicStoreOfficial;");
            conn.Open();
            NpgsqlCommand com = new NpgsqlCommand("select s.songname from song s,artist a,arecords r where s.songid=r.songid and r.artistid=a.artistid and a.artistname='"+ArtistList.SelectedItem.ToString()+"'", conn);
            NpgsqlDataReader dr = com.ExecuteReader();
            while (dr.Read())
            {
                ListPanel.Items.Add(dr[0].ToString());
            }
            conn.Close();
        }

        // Lista od Albumi
        private void btnAlbums_Click(object sender, EventArgs e)
        {
            AlbumList.Items.Clear();
            AlbumList.Visible = true;
            ArtistList.Visible = false;
            buySongPanel.Visible = false;
            ListPanel.Visible = false;
            listGenres.Visible = false;
            MyProfilePanel.Visible = false;
            MySongsList.Visible = false;
            NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;User Id=Filip;" + "Password=123;Database=MusicStoreOfficial;");
            conn.Open();
            NpgsqlCommand com2 = new NpgsqlCommand("select * from album", conn);
            NpgsqlDataReader dr2 = com2.ExecuteReader();
            
            while (dr2.Read())
            {
                AlbumList.Items.Add(dr2[1].ToString());
            }
            conn.Close();

        }

        private void AlbumList_SelectedIndexChanged(object sender, EventArgs e)
        {
            AlbumPanel.Visible = true;
            NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;User Id=Filip;" + "Password=123;Database=MusicStoreOfficial;");
            conn.Open();
            NpgsqlCommand com1 = new NpgsqlCommand("select * from album where albumname='"+AlbumList.SelectedItem.ToString()+"'", conn);
            NpgsqlDataReader dr2 = com1.ExecuteReader();
            dr2.Read();
            ImeNaAlbumot.Text = dr2[1].ToString();
            GodinaNaSnimanje.Text = dr2[2].ToString();
            CoverNaAlbumot.Image = System.Drawing.Image.FromFile(dr2[3].ToString());
            conn.Close();
            conn.Open();
            NpgsqlCommand com2 = new NpgsqlCommand("select count(s.songname),a.albumname from song s,album a where s.albumid=a.albumid and albumname='" + AlbumList.SelectedItem.ToString() + "'  group by (a.albumname) ", conn);
            NpgsqlDataReader dr1 = com2.ExecuteReader();
            dr1.Read();
            BrojNaPesni.Text = dr1[0].ToString();
            conn.Close();
            conn.Open();
            NpgsqlCommand com3 = new NpgsqlCommand("select a.artistname from album al, artist a where a.artistid = al.artistid and al.albumname = '" + AlbumList.SelectedItem.ToString() + "' ", conn);
            NpgsqlDataReader dr3 = com3.ExecuteReader();
            dr3.Read();
            if (AlbumList.SelectedItem.ToString().Equals("No Album"))
            {
                ImeNaArtistot.Text = "Many";
            }
            else { ImeNaArtistot.Text = dr3[0].ToString();}
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AlbumPanel.Visible = false;
            AlbumList.Visible = false;
            ListPanel.Items.Clear();
            ListPanel.Visible = true;
            NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;User Id=Filip;" + "Password=123;Database=MusicStoreOfficial;");
            conn.Open();
            NpgsqlCommand com1 = new NpgsqlCommand("select s.songname from song s,album a where s.albumid=a.albumid and a.albumname='" + AlbumList.SelectedItem.ToString() + "'", conn);
            NpgsqlDataReader dr2 = com1.ExecuteReader();
            while (dr2.Read())
            {
                ListPanel.Items.Add(dr2[0].ToString());
            }
            conn.Close();
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        
        

       

       
    }
}
