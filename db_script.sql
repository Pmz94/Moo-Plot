use ganado;

CREATE TABLE IF NOT EXISTS `animales` (
`ID_Animal` int(11) NOT NULL,
  `Num_Caravana` int(11) NOT NULL,
  `Especie` varchar(30) NOT NULL,
  `Raza` varchar(30) NOT NULL,
  `Genero` varchar(25) NOT NULL,
  `Fecha_Nac` date NOT NULL,
  `Peso_Nac` float NOT NULL,
  `IMC_Actual` float NOT NULL,
  `Observaciones` text,
  `Cod_Signia` int(11) NOT NULL,
  `Status` boolean NOT NULL,
  `Fecha_Muerte` date DEFAULT NULL,
  `Imagen_(Ruta)` varchar(80) DEFAULT NULL,
  `Imagen_(Foto)` blob,
  `Peso_Actual` float NOT NULL,
  `Celo` date DEFAULT NULL
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `animales`
--

INSERT INTO `animales` (`ID_Animal`, `Num_Caravana`, `Especie`, `Raza`, `Genero`, `Fecha_Nac`, `Peso_Nac`, `IMC_Actual`, `Observaciones`, `Cod_Signia`, `Status`, `Fecha_Muerte`, `Imagen_(Ruta)`, `Imagen_(Foto)`, `Peso_Actual`, `Celo`) VALUES
(5, 689, 'Vaca', 'Lechera', 'Hembra', '2012-11-07', 132, 73.04, NULL, 2233, true, NULL, NULL, NULL, 650, '2016-11-14'),
(6, 689, 'Toro', 'PuraSangre', 'Macho', '2011-11-07', 200, 80.6, NULL, 2341, true, NULL, NULL, NULL, 1000, NULL);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `animales_enfermos`
--

CREATE TABLE IF NOT EXISTS `animales_enfermos` (
`ID_enfermo` int(11) NOT NULL,
  `ID_animal` int(11) NOT NULL,
  `ID_enfermedad` int(11) NOT NULL,
  `Descripcion` varchar(40) NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `animales_enfermos`
--

INSERT INTO `animales_enfermos` (`ID_enfermo`, `ID_animal`, `ID_enfermedad`, `Descripcion`) VALUES
(3, 5, 1, ''),
(4, 5, 2, ''),
(7, 6, 2, '');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `enfermedades`
--

CREATE TABLE IF NOT EXISTS `enfermedades` (
`ID_enfermedad` int(11) NOT NULL,
  `Nom_Enfermedad` varchar(25) NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `enfermedades`
--

INSERT INTO `enfermedades` (`ID_enfermedad`, `Nom_Enfermedad`) VALUES
(1, 'Diabetes'),
(2, 'Cancer');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `ranchos`
--

CREATE TABLE IF NOT EXISTS `ranchos` (
`ID_Rancho` int(11) NOT NULL,
  `Nombre_Rancho` varchar(25) NOT NULL,
  `Estado` varchar(25) NOT NULL,
  `Ciudad` varchar(25) NOT NULL,
  `Hectareas` int(11) NOT NULL,
  `Dueño` varchar(25) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `reproduccion`
--

CREATE TABLE IF NOT EXISTS `reproduccion` (
`ID_Reprod` int(11) NOT NULL,
  `ID_Animal` int(11) NOT NULL,
  `ID_Padre` int(11) NOT NULL,
  `Embarazos` int(11) NOT NULL,
  `Partos` int(11) NOT NULL,
  `Abortos` int(11) DEFAULT NULL,
  `Partos_Complicaciones` int(11) DEFAULT NULL
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `usuarios`
--

CREATE TABLE IF NOT EXISTS `usuarios` (
`ID` int(11) NOT NULL,
  `Nombre` varchar(20) NOT NULL,
  `Apellido(s)` varchar(30) NOT NULL,
  `Correo` varchar(30) NOT NULL,
  `Contrasena` varchar(20) NOT NULL,
  `Telefono` varchar(10) NOT NULL,
  `Fecha_Nac` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `animales`
--
ALTER TABLE `animales`
 ADD PRIMARY KEY (`ID_Animal`), ADD UNIQUE KEY `Cod_Signia` (`Cod_Signia`);

--
-- Indices de la tabla `animales_enfermos`
--
ALTER TABLE `animales_enfermos`
 ADD PRIMARY KEY (`ID_enfermo`), ADD KEY `ID_animal_3` (`ID_animal`,`ID_enfermedad`), ADD KEY `ID_animal_2` (`ID_animal`,`ID_enfermedad`), ADD KEY `ID_animal` (`ID_animal`), ADD KEY `ID_enfermedad` (`ID_enfermedad`);

--
-- Indices de la tabla `enfermedades`
--
ALTER TABLE `enfermedades`
 ADD PRIMARY KEY (`ID_enfermedad`);

--
-- Indices de la tabla `ranchos`
--
ALTER TABLE `ranchos`
 ADD PRIMARY KEY (`ID_Rancho`);

--
-- Indices de la tabla `reproduccion`
--
ALTER TABLE `reproduccion`
 ADD PRIMARY KEY (`ID_Reprod`), ADD UNIQUE KEY `ID_Animal` (`ID_Animal`);

--
-- Indices de la tabla `usuarios`
--
ALTER TABLE `usuarios`
 ADD PRIMARY KEY (`ID`), ADD UNIQUE KEY `Correo` (`Correo`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `animales`
--
ALTER TABLE `animales`
MODIFY `ID_Animal` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=7;
--
-- AUTO_INCREMENT de la tabla `animales_enfermos`
--
ALTER TABLE `animales_enfermos`
MODIFY `ID_enfermo` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=8;
--
-- AUTO_INCREMENT de la tabla `enfermedades`
--
ALTER TABLE `enfermedades`
MODIFY `ID_enfermedad` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=3;
--
-- AUTO_INCREMENT de la tabla `ranchos`
--
ALTER TABLE `ranchos`
MODIFY `ID_Rancho` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT de la tabla `reproduccion`
--
ALTER TABLE `reproduccion`
MODIFY `ID_Reprod` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=6;
--
-- AUTO_INCREMENT de la tabla `usuarios`
--
ALTER TABLE `usuarios`
MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT;
--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `animales_enfermos`
--
ALTER TABLE `animales_enfermos`
ADD CONSTRAINT `animales_enfermos_ibfk_1` FOREIGN KEY (`ID_animal`) REFERENCES `animales` (`ID_Animal`) ON DELETE CASCADE ON UPDATE CASCADE,
ADD CONSTRAINT `animales_enfermos_ibfk_2` FOREIGN KEY (`ID_enfermedad`) REFERENCES `enfermedades` (`ID_enfermedad`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Filtros para la tabla `reproduccion`
--
ALTER TABLE `reproduccion`
ADD CONSTRAINT `reproduccion_ibfk_1` FOREIGN KEY (`ID_Animal`) REFERENCES `animales` (`ID_Animal`) ON DELETE CASCADE ON UPDATE CASCADE;
