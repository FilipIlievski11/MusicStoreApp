-- Database: "MusicStoreOfficial"

-- DROP DATABASE "MusicStoreOfficial";

CREATE DATABASE "MusicStoreOfficial"
  WITH OWNER = postgres
       ENCODING = 'UTF8'
       TABLESPACE = pg_default
       LC_COLLATE = 'English_United States.1252'
       LC_CTYPE = 'English_United States.1252'
       CONNECTION LIMIT = -1;
ALTER TABLE artist DROP COLUMN origin
select * from song
select * from artist
select * from album
ALTER TABLE song ADD COLUMN songURL varchar(500);

drop table categories;
drop table artist;
drop table useracc;
drop table country;
drop table album;
drop table artist;
drop table song;

insert into album(albumname,albumdate,albumurl,artistid) values('Le Magree album','5.10.2003','dsada','1')

insert into song(songname,songdate,songlength,songprice,categoriesid,albumid,songurl) values('dasda','dsada','dsada','5','1','1','dsada')UPDATE useracc
UPDATE song
SET categoriesid='2'
WHERE songid='11';

select count(s.songname),a.albumname from song s,album a where s.albumid=a.albumid group by (a.albumname)

select a.artistname from album al, artist a where a.artistid=al.artistid and al.albumname='No Album'

select songurl from song where songname='Le Magreen - Times They May Pass (Steel Guitar Version).mp3'

DELETE FROM album where albumname='No Album'

insert into artist(artistname) values('None');
insert into album(albumname,albumdate,albumurl,artistid) values('No Album','No Date','D:\MusicStore\AlbumsPictures\NoAlbum.png','1');
select * from artist
select * from album


//country artisti albumi pesni
insert into artist(artistname) values('Spare Line');
insert into artist(artistname) values('Jerry BloomTown');
insert into artist(artistname) values('The Alberts');
insert into artist(artistname) values('Carpe Diem');
insert into artist(artistname) values('MC Grisdinili');

insert into arecords(songid,artistid) values('6','6');
insert into arecords(songid,artistid) values('3','3');
insert into arecords(songid,artistid) values('4','4');
insert into arecords(songid,artistid) values('5','5');

select * from song
select * from arecords

// rock 
insert into artist(artistname) values('AC/DC');
insert into artist(artistname) values('The Rolling Stones');

insert into arecords(songid,artistid) values('11','8');

// punk
insert into artist(artistname) values('NOFX');
insert into artist(artistname) values('Ramones');

insert into arecords(songid,artistid) values('12','9');
insert into arecords(songid,artistid) values('13','10');
insert into arecords(songid,artistid) values('14','10');
insert into arecords(songid,artistid) values('15','10');
insert into arecords(songid,artistid) values('16','10');

// metal
insert into artist(artistname) values('Children of Bodom');
insert into artist(artistname) values('Diablo');
insert into artist(artistname) values('The Scourger');
insert into artist(artistname) values('Insomnium');
insert into artist(artistname) values('Stratovarius');

insert into arecords(songid,artistid) values('17','11');
insert into arecords(songid,artistid) values('18','12');
insert into arecords(songid,artistid) values('19','13');
insert into arecords(songid,artistid) values('20','14');
insert into arecords(songid,artistid) values('21','15');

// Pop
insert into artist(artistname) values('Aretha Franklin');
insert into artist(artistname) values('Backstreet Boys');
insert into artist(artistname) values('Jackson 5');
insert into artist(artistname) values('Madonna');
insert into artist(artistname) values('U2');

insert into arecords(songid,artistid) values('23','16');
insert into arecords(songid,artistid) values('24','17');
insert into arecords(songid,artistid) values('25','18');
insert into arecords(songid,artistid) values('26','19');
insert into arecords(songid,artistid) values('27','20');

// Techno
insert into artist(artistname) values('Dj Jose vs G Spott');
insert into artist(artistname) values('Dj Satomi');
insert into artist(artistname) values('Pol Van Dyke');
insert into artist(artistname) values('Rodgers Sanchez');

insert into arecords(songid,artistid) values('28','26');
insert into arecords(songid,artistid) values('29','26');
insert into arecords(songid,artistid) values('30','27');
insert into arecords(songid,artistid) values('31','28');
insert into arecords(songid,artistid) values('32','29');

// Trance
insert into artist(artistname) values('Antiloop');
insert into artist(artistname) values('Armand Van Helden');
insert into artist(artistname) values('Base Attack');
insert into artist(artistname) values('Benny Benassi Bross');
insert into artist(artistname) values('Creambase');

insert into arecords(songid,artistid) values('33','30');
insert into arecords(songid,artistid) values('34','31');
insert into arecords(songid,artistid) values('35','32');
insert into arecords(songid,artistid) values('36','33');
insert into arecords(songid,artistid) values('37','34');

// HipHop
insert into artist(artistname) values('2Pac');
insert into artist(artistname) values('A Tribe Called Quest');
insert into artist(artistname) values('Big Daddy Kane');
insert into artist(artistname) values('Black Sheep');
insert into artist(artistname) values('Eazy E');

insert into arecords(songid,artistid) values('38','35');
insert into arecords(songid,artistid) values('39','36');
insert into arecords(songid,artistid) values('40','37');
insert into arecords(songid,artistid) values('41','38');
insert into arecords(songid,artistid) values('42','39');

select * from artist
select * from song
delete from song
where songid='22'
// metal

//--------------------------------------------------
-- Schema: public

-- DROP SCHEMA public;

CREATE SCHEMA public
  AUTHORIZATION postgres;

GRANT ALL ON SCHEMA public TO postgres;
GRANT ALL ON SCHEMA public TO public;
COMMENT ON SCHEMA public
  IS 'standard public schema';

select * from useracc
select * from useracc where username='Admin';
ALTER TABLE korisnik DROP COLUMN drzava

ALTER TABLE useracc ADD COLUMN userURL varchar(500); 

drop table korisnik

create table country(
countryID serial,
countryName char(30),
constraint pk_country primary key (countryID)
);


insert into country(countryName) values('Macedonia');
insert into country(countryName) values('Greece');
insert into country(countryName) values('Albania');
insert into country(countryName) values('Serbia');
insert into country(countryName) values('Croatia');
insert into country(countryName) values('United States');
insert into country(countryName) values('United Kingdom');
insert into country(countryName) values('France');
insert into country(countryName) values('Bulgaria');
insert into country(countryName) values('Germany');
insert into country(countryName) values('Russia');
insert into country(countryName) values('Denmark');
insert into country(countryName) values('Spain');
insert into country(countryName) values('Sweden');
insert into country(countryName) values('Others');

select * from country
select countryID from country where countryName='Albania'


create table useracc(
userID serial,
username char(30),
userpassword char(30),
firstname char(30),
secondname char(30),
countryID serial,
constraint pk_user primary key (userID),
constraint fk_user_to_country foreign key (countryID) references country(countryID)
);
select * from useracc

create table categories(
categoriesID serial,
categoriesName char(30),
constraint pk_categories primary key (categoriesID)
)
drop table categories
insert into categories(categoriesName) values('Country');
insert into categories(categoriesName) values('Rock');
insert into categories(categoriesName) values('Punk');
insert into categories(categoriesName) values('Metal');
insert into categories(categoriesName) values('Pop');
insert into categories(categoriesName) values('Trance');
insert into categories(categoriesName) values('Techno');
insert into categories(categoriesName) values('HipHop');
select * from categories

UPDATE useracc
SET userpassword = '1234'
WHERE username = 'Admin';

select * from useracc

create table artist(
artistID serial,
artistName char(50),
origin char(30),
constraint pk_artist primary key (artistID)
);

create table album(
albumID serial,
albumName char(50),
albumDate char(50),
albumUrl varchar(500),
artistID serial,
constraint pk_album primary key(albumID),
constraint fk_album_to_artist foreign key(artistID) references artist(artistID)
);

create table song(
songID serial,
songName char(100),
songDate char(50),
songLength char(100),
songPrice int,
categoriesID serial,
albumID serial,
constraint pk_song primary key(songID),
constraint fk_song_to_categories foreign key(categoriesID) references categories(categoriesID),
constraint fk_song_to_albums foreign key(albumID) references album(albumID)
);

create table arecords(
songID serial,
artistID serial,
constraint pk_arecords primary key(songID,artistID),
constraint fk_arecords_to_songs foreign key(songID) references song(songID),
constraint fk_arecords_to_artists foreign key(artistID) references artist(artistID)
);

create table rating(
songID serial,
userID serial,
stars integer,
constraint pk_rating primary key(songID,userID),
constraint fk_rating_to_songs foreign key(songID) references song(songID),
constraint fk_rating_to_useracc foreign key(userID) references useracc(userID)
);
create table boughtsong(
songID serial,
userID serial,
constraint pk_boughtsong primary key(songID,userID),
constraint fk_boughtsong_to_songs foreign key(songID) references song(songID),
constraint fk_boughtsong_to_useracc foreign key(userID) references useracc(userID)
);

insert into boughtsong(songID,userID) values('3','2')

select s.songname,s.songurl,u.username from song s, useracc u,boughtsong bs where s.songID=bs.songID and bs.userID=u.userID and u.username='uuu'

select * from boughtsong
select * from useracc
select * from country
select * from categories
select * from song

select s.songname,s.songdate,s.songlength,s.songprice,a.artistname from song s,artist a,arecords where s.songid=arecords.songid and arecords.artistid=a.artistid and s.songname='Delia Says - Spare Line.mp3'

select * from rating                                                               

select s.songname, round(avg(r.stars),2) from song s,rating r,useracc u,country c 
where c.countryid=u.countryid and u.userid=r.userid and s.songid=r.songid group by (s.songname)

select * from country

select d.imeDrzava, p.pesnaID ,p.pesnaIme, max(r.zvezdi)

from Drzava d 

join Korisnik k on d.idDrzava=k.idDrzava

join Rejting r on r.korID=k.korID

join Pesni p on p.pesnaID= r.pesnaID

group by d.imeDrzava

select round(avg(r.stars),2) from country c join useracc u on c.countryid=u.countryid join rating r on r.userid=u.userid join song s on r.songid=s.songid 
where c.countryname='Sweden'
group by c.countryname

select countryname from country c,useracc u where c.countryid=u.countryid and u.username='Ema'

select * from album where artistname='Coldplay'
insert into album(albumname,albumdate,albumurl,artistid) values('Parachutes','2000','D:\MusicStore\AlbumsPictures\Parachutes - Coldplay (Front) [2000].jpg','40')
select s.songname from song s,useracc u, boughtsong bs where s.songid=bs.songid and u.userid=bs.userid
select s.songname from song s,artist a,arecords r where s.songid=r.songid and r.artistid=a.artistid and a.artistname='Spare Line'

select * from rating
insert into rating(songid,userid,stars) values('6','2','3')

insert into arecords(songid,artistid) values('43','40');
insert into arecords(songid,artistid) values('44','40');
insert into arecords(songid,artistid) values('45','40');
insert into arecords(songid,artistid) values('46','40');
insert into arecords(songid,artistid) values('47','40');
insert into arecords(songid,artistid) values('48','40');
insert into arecords(songid,artistid) values('49','40');
insert into arecords(songid,artistid) values('50','40');
insert into arecords(songid,artistid) values('51','40');
insert into arecords(songid,artistid) values('52','40');
insert into arecords(songid,artistid) values('53','40');
select * from album

insert into album(albumname,albumdate,albumurl,artistid) values('Silent Alarm','2005','D:\MusicStore\AlbumsPictures\R-401388-1403975232-1726.jpeg.jpg','41')
insert into arecords(songid,artistid) values('54','41');
insert into arecords(songid,artistid) values('55','41');
insert into arecords(songid,artistid) values('56','41');
insert into arecords(songid,artistid) values('57','41');
insert into arecords(songid,artistid) values('58','41');
insert into arecords(songid,artistid) values('59','41');
insert into arecords(songid,artistid) values('60','41');
insert into arecords(songid,artistid) values('61','41');
insert into arecords(songid,artistid) values('62','41');
insert into arecords(songid,artistid) values('63','41');
insert into arecords(songid,artistid) values('64','41');
insert into arecords(songid,artistid) values('65','41');
select * from song


select * from album