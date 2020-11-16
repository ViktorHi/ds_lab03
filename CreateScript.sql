DROP SCHEMA IF EXISTS `polyclinic`;
CREATE SCHEMA `polyclinic` DEFAULT CHARACTER SET utf8;
USE `polyclinic`;
-- -----------------------------------------------------
-- Table `Polyclinic`.`tokens`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Tokens` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `line` VARCHAR(255) NOT NULL,
  `server_name` VARCHAR(255) NOT NULL,
  `server_user_name` VARCHAR(255) NOT NULL,
  PRIMARY KEY (`id`));

CREATE TABLE IF NOT EXISTS `Token_payment` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `token` VARCHAR(255) NOT NULL,
  `function` VARCHAR(255) NOT NULL,
  `day1` DATE NOT NULL,
  `day2` DATE NOT NULL,
  PRIMARY KEY (`id`));

-- -----------------------------------------------------
-- Table `Polyclinic`.`visits`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Visits` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `user_fio` VARCHAR(45) NOT NULL,
  `date_visit` DATE NOT NULL,
  `specialization` VARCHAR(45) NOT NULL,
  `doctor_fio` VARCHAR(45) NULL,
  PRIMARY KEY (`id`));
  
    
INSERT INTO Tokens(line,server_name,server_user_name) VALUES('123456789','PolyclinincService','DefaultPolyclynicUser');
INSERT INTO Token_payment(token,`function`,day1,day2) VALUES('123456789','Create','2010-1-1','2030-1-1');
INSERT INTO Token_payment(token,`function`,day1,day2) VALUES('123456789','Update','2010-1-1','2030-1-1');
INSERT INTO Token_payment(token,`function`,day1,day2) VALUES('123456789','Delete','2010-1-1','2030-1-1');
INSERT INTO Token_payment(token,`function`,day1,day2) VALUES('123456789','Get','2010-1-1','2030-1-1');
INSERT INTO Visits(user_fio,date_visit,specialization,doctor_fio) VALUES('Perseus','2012-1-1','Surgeon','Adler');
