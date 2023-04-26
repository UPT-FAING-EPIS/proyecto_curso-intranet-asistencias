-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Versión del servidor:         10.4.24-MariaDB - mariadb.org binary distribution
-- SO del servidor:              Win64
-- HeidiSQL Versión:             11.3.0.6295
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- Volcando estructura de base de datos para bd_asistencia
CREATE DATABASE IF NOT EXISTS `bd_asistencia` /*!40100 DEFAULT CHARACTER SET utf8mb4 */;
USE `bd_asistencia`;

-- Volcando estructura para tabla bd_asistencia.tb_asistencia
CREATE TABLE IF NOT EXISTS `tb_asistencia` (
  `codasistencia` int(9) DEFAULT NULL,
  `Dia` int(8) DEFAULT NULL,
  `estado` varchar(1) DEFAULT 'F',
  `fk_idcurso` varchar(50) DEFAULT NULL,
  KEY `FK_tb_asistencia_tb_curso` (`fk_idcurso`),
  CONSTRAINT `FK_tb_asistencia_tb_curso` FOREIGN KEY (`fk_idcurso`) REFERENCES `tb_curso` (`idcurso`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- Volcando datos para la tabla bd_asistencia.tb_asistencia: ~0 rows (aproximadamente)
/*!40000 ALTER TABLE `tb_asistencia` DISABLE KEYS */;
/*!40000 ALTER TABLE `tb_asistencia` ENABLE KEYS */;

-- Volcando estructura para tabla bd_asistencia.tb_curso
CREATE TABLE IF NOT EXISTS `tb_curso` (
  `idcurso` varchar(50) NOT NULL,
  `nomcurso` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`idcurso`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- Volcando datos para la tabla bd_asistencia.tb_curso: ~0 rows (aproximadamente)
/*!40000 ALTER TABLE `tb_curso` DISABLE KEYS */;
/*!40000 ALTER TABLE `tb_curso` ENABLE KEYS */;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
