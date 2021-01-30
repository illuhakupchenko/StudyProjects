CREATE DATABASE  IF NOT EXISTS `university` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `university`;
-- MySQL dump 10.13  Distrib 8.0.19, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: university
-- ------------------------------------------------------
-- Server version	8.0.19

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `syllabus`
--

DROP TABLE IF EXISTS `syllabus`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `syllabus` (
  `id` int NOT NULL AUTO_INCREMENT,
  `subjname` varchar(45) NOT NULL,
  `teacher` varchar(45) NOT NULL,
  `hours` varchar(45) NOT NULL,
  `exam` varchar(45) NOT NULL,
  `groupname` varchar(45) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=23 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `syllabus`
--

LOCK TABLES `syllabus` WRITE;
/*!40000 ALTER TABLE `syllabus` DISABLE KEYS */;
INSERT INTO `syllabus` VALUES (1,'Економіка програмного забезпечення','Калініна Тетяна Олегівна','12','Так','ІПЗ-4.2.03'),(2,'Професійна практика програмної інженерії','Заврак Микола Володимирович','10','Так','РТТ-48'),(3,'Програмування для мобільних платформ','Трофименко Олег Григорович','8','Ні','ОПГ-98'),(4,'Моделювання систем','Манаков Сергій Юрійович','10','Ні','РТТ-48'),(5,'Криптографія та криптоаналіз','Ісмаілова Надія Павлівна','10','Так','ОПГ-98'),(6,'Мобільні комунікації','Глазунова Людмила Валеріївна','12','Ні','ІПЗ-4.2.03'),(7,'Управління IT-проектами','Малахов Едуард Володимирович','10','Ні','РТТ-48'),(8,'Python-програмування','Панченко Борис Єгорович','8','Ні','РПЗ-42'),(9,'Безпека програм та даних','Єгошина Галина Анатоліївна','12','Так','ІПЗ-4.2.03'),(10,'Якість програмного забезпечення та тестування','Глазунова Людмила Валеріївна','8','Так','РПЗ-42'),(11,'Інформатика','Романюк Вадим Васильович','10','Так','ІПЗ-4.2.03'),(12,'Вища математика','Прокоп Юлія Володимирівна','10','Ні','ОПГ-98'),(13,'Організація бази даних','Яценко Володимир Євгенієвич','8','Ні','РПЗ-42'),(14,'Системне адміністрування','Чепок Анатолій Олекснадрович','12','Так','РТТ-48'),(15,'Теорія інформації та кодування','Буката Людмила Михайлівна','8','Ні','ІПЗ-4.2.03'),(16,'Web-дизайн','Шнайдер Сергій Петрович','10','Ні','РТТ-48'),(17,'Конструювання програмного забезпечення','Ісмаілова Надія Павлівна','8','Так','РПЗ-42'),(18,'Моделювання ПЗ','Трофименко Олег Григорович','12','Так','ІПЗ-4.2.03');
/*!40000 ALTER TABLE `syllabus` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2020-04-19 20:44:53
