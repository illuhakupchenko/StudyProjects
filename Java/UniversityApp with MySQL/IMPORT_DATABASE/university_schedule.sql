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
-- Table structure for table `schedule`
--

DROP TABLE IF EXISTS `schedule`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `schedule` (
  `id` int NOT NULL AUTO_INCREMENT,
  `unitnumber` varchar(45) NOT NULL,
  `subjname` varchar(45) NOT NULL,
  `classnumber` varchar(45) NOT NULL,
  `groupname` varchar(45) NOT NULL,
  `studyday` varchar(45) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=29 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `schedule`
--

LOCK TABLES `schedule` WRITE;
/*!40000 ALTER TABLE `schedule` DISABLE KEYS */;
INSERT INTO `schedule` VALUES (1,'1','Інформатика','023','ІПЗ-4.2.03','Понеділок'),(2,'2','Теорія інформації та кодування','012','ІПЗ-4.2.03','Понеділок'),(3,'3','Моделювання ПЗ','020','ІПЗ-4.2.03','Понеділок'),(4,'1','Професійна практика програмної інженерії','011','РТТ-48','Понеділок'),(5,'1','Програмування для мобільних платформ','009','ОПГ-98','Понеділок'),(6,'1','Конструювання програмного забезпечення','007','РПЗ-42','Понеділок'),(7,'1','Якість програмного забезпечення та тестування','005','РПЗ-42','Вівторок'),(8,'1','Вища математика','015','ОПГ-98','Вівторок'),(9,'1','Криптографія та криптоаналіз','013','РТТ-48','Вівторок'),(10,'1','Мобільні комунікації','014','ІПЗ-4.2.03','Вівторок'),(15,'2','Економіка програмного забезпечення','012','РТТ-48','Понеділок'),(16,'1','Професійна практика програмної інженерії','013','РТТ-48','Середа'),(17,'1','Мобільні комунікації','019','РТТ-48','Четвер'),(18,'1','Управління IT-проектами','017','РТТ-48','П\'ятниця'),(19,'1','Криптографія та криптоаналіз','011','РПЗ-42','П\'ятниця'),(20,'1','Якість програмного забезпечення та тестування','019','РПЗ-42','Четвер'),(21,'1','Безпека програм та даних','019','РПЗ-42','Середа'),(22,'1','Моделювання систем','003','ІПЗ-4.2.03','Середа'),(23,'1','Управління IT-проектами','021','ІПЗ-4.2.03','Четвер'),(24,'1','Безпека програм та даних','004','ІПЗ-4.2.03','П\'ятниця'),(25,'1','Мобільні комунікації','005','ОПГ-98','П\'ятниця'),(26,'1','Програмування для мобільних платформ','012','ОПГ-98','Четвер'),(27,'1','Якість програмного забезпечення та тестування','2','ОПГ-98','Середа'),(28,'3','Моделювання систем','010','РТТ-48','Понеділок');
/*!40000 ALTER TABLE `schedule` ENABLE KEYS */;
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
