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
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `users` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(45) NOT NULL,
  `surname` varchar(45) NOT NULL,
  `secname` varchar(45) NOT NULL,
  `position` varchar(45) NOT NULL,
  `academic_degree` varchar(45) NOT NULL,
  `login` varchar(45) NOT NULL,
  `password` varchar(45) NOT NULL,
  `telephone` varchar(45) NOT NULL DEFAULT '-',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=33 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES (1,'Вадим','Романюк','Васильович','завідуючий кафедри, професор','професор, д.т.н.','1','1','6654654'),(2,'Борис','Панченко','Єгорович','професор','професор, д.т.н','panch','panch','654654'),(3,'Надія','Ісмаілова','Павлівна','професор','професор, д.т.н','isma','palna','645645'),(4,'Едуард','Малахов','Володимирович','професор','професор, д.т.н.','malakhov','prof','546446'),(5,'Людмила','Глазунова','Валеріївна','доцент','доцент, к.ф-м.н.','glazun','ludam','546456456'),(6,'Галина','Єгошина','Анатоліївна','доцент','доцент, к.т.н.','galina','egosh','6456546'),(7,'Микола','Заврак','Володимирович','доцент','доцент, к.т.н.','zavrak','mikola','6456546'),(8,'Тетяна','Калініна','Олегівна','доцент','доцент, к.т.н.','kalina','tania','645654'),(9,'Олег','Трофименко','Григорович','доцент','доцент, к.т.н.','oleg','trofim','64564'),(10,'Юлія','Прокоп','Володимирівна','ст.викладач','к.і.н.','julia','vladim','6456546'),(11,'Сергій','Манаков','Юрійович','ст. вкикладач','-','mana','seriy','6456546'),(12,'Людмила','Косирєва','Андріївна','ст. вкикладач','-','ludmilaya','kosar','6546546'),(13,'Володимир','Яценко','Євгенієвич','ст. вкикладач','-','vladimir2','evgenich','6456546'),(14,'Людмила','Буката','Михайлівна','ст. вкикладач','-','bukatayaa','lbuk','64546456'),(15,'Анатолій','Чепок','Олександрович','ст. вкикладач','-','toliak','oleks','6456546'),(16,'Сергій','Шнайдер','Петрович','ст. вкикладач','-','shnaider','iam','6546546'),(17,'Марина','Бобікова','Григорівна','вкикладач','-','bobik','marinka','6456546'),(18,'Ірина','Гребініна','Вікторівна','вкикладач','-','2','2','6456456');
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
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
