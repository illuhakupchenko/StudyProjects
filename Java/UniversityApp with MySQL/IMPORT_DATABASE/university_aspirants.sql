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
-- Table structure for table `aspirants`
--

DROP TABLE IF EXISTS `aspirants`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `aspirants` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(45) NOT NULL,
  `surname` varchar(45) NOT NULL,
  `secname` varchar(45) NOT NULL,
  `supervisor` varchar(45) NOT NULL,
  `sci_direction` mediumtext NOT NULL,
  `theme` longtext NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=28 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspirants`
--

LOCK TABLES `aspirants` WRITE;
/*!40000 ALTER TABLE `aspirants` DISABLE KEYS */;
INSERT INTO `aspirants` VALUES (1,'Іван','Головін','Петрович','Малахов Едуард Володимирович','Інформатика та обчислювальна техніка','Розробка ком\'пютерних програм для моделювання перенесення багатокомпонентних рідин по тріщині гідророзриву пласта'),(2,'Марія','Чурай','Вікторівна','Єгошина Галина Анатоліївна','Математичне і програмне забезпечення обчислювальних машин, комплексів і комп\'ютерних мереж','Розробка засобів аналізу функціонування і розрахунку показників надійності розподілених обчислювальних систем'),(3,'Василь','Сусанін','Миколайович','Калініна Тетяна Олегівна','Математичне і програмне забезпечення обчислювальних машин, комплексів і компютерних мереж','Вивчення впливу сферичності Землі на результати чисельного моделювання поширення цунамі'),(4,'Петро','Гулько','Опанасович','Заврак Микола Володимирович','Інформатика та обчислювальна техніка','Дослідження ефективності методів класифікації і кластеризації');
/*!40000 ALTER TABLE `aspirants` ENABLE KEYS */;
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
