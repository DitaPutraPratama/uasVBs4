-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Waktu pembuatan: 12 Jul 2022 pada 11.34
-- Versi server: 10.4.22-MariaDB
-- Versi PHP: 8.1.1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `dbpupuk`
--

-- --------------------------------------------------------

--
-- Struktur dari tabel `tbadmin`
--

CREATE TABLE `tbadmin` (
  `id_admin` int(5) NOT NULL,
  `username` varchar(20) NOT NULL,
  `pwd` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data untuk tabel `tbadmin`
--

INSERT INTO `tbadmin` (`id_admin`, `username`, `pwd`) VALUES
(1, 'admin', 'admin');

-- --------------------------------------------------------

--
-- Struktur dari tabel `tbkeluar`
--

CREATE TABLE `tbkeluar` (
  `id_keluar` int(5) NOT NULL,
  `nik` varchar(20) NOT NULL,
  `id_pupuk` varchar(5) NOT NULL,
  `tglkeluar` date NOT NULL,
  `jumlah_keluar` int(10) NOT NULL,
  `harga_total` int(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data untuk tabel `tbkeluar`
--

INSERT INTO `tbkeluar` (`id_keluar`, `nik`, `id_pupuk`, `tglkeluar`, `jumlah_keluar`, `harga_total`) VALUES
(1, '1234567890000001', '02', '2022-07-07', 2, 170000),
(3, '1234567890000003', '02', '2022-07-07', 1, 170000),
(4, '1234567890000004', '02', '2022-07-07', 2, 170000),
(6, '1234567890000002', '02', '2022-07-07', 2, 170000),
(9, '1234567890000002', '04', '2022-07-07', 1, 115000);

-- --------------------------------------------------------

--
-- Struktur dari tabel `tbpenerima`
--

CREATE TABLE `tbpenerima` (
  `nik` varchar(20) NOT NULL,
  `nama` varchar(20) NOT NULL,
  `jk` varchar(10) NOT NULL,
  `hp` varchar(15) NOT NULL,
  `alamat` varchar(70) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data untuk tabel `tbpenerima`
--

INSERT INTO `tbpenerima` (`nik`, `nama`, `jk`, `hp`, `alamat`) VALUES
('1234567890000001', 'yanto', 'Laki-laki', '085234567890', 'ndawung rt 03'),
('1234567890000002', 'jono', 'Laki-laki', '085209871234', 'ndawung rt 03'),
('1234567890000003', 'yatini', 'Perempuan', '085123450987', 'mbutuh rt03'),
('1234567890000004', 'sinem', 'Perempuan', '085292384756', 'ndawung rt04');

-- --------------------------------------------------------

--
-- Struktur dari tabel `tbpupuk`
--

CREATE TABLE `tbpupuk` (
  `id_pupuk` char(5) NOT NULL,
  `nama` varchar(20) NOT NULL,
  `jumlah` int(10) NOT NULL,
  `harga` int(10) NOT NULL,
  `tglmasuk` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data untuk tabel `tbpupuk`
--

INSERT INTO `tbpupuk` (`id_pupuk`, `nama`, `jumlah`, `harga`, `tglmasuk`) VALUES
('01', 'UREA', 29, 112500, '2022-07-06'),
('02', 'ZA', 12, 85000, '2022-07-06'),
('03', 'SP-36', 33, 120000, '2022-07-07'),
('04', 'NPK PHONSKA', 27, 115000, '2022-07-07'),
('05', 'PETROGANIK', 34, 32000, '2022-07-07');

--
-- Indexes for dumped tables
--

--
-- Indeks untuk tabel `tbadmin`
--
ALTER TABLE `tbadmin`
  ADD PRIMARY KEY (`id_admin`);

--
-- Indeks untuk tabel `tbkeluar`
--
ALTER TABLE `tbkeluar`
  ADD PRIMARY KEY (`id_keluar`);

--
-- Indeks untuk tabel `tbpenerima`
--
ALTER TABLE `tbpenerima`
  ADD PRIMARY KEY (`nik`);

--
-- Indeks untuk tabel `tbpupuk`
--
ALTER TABLE `tbpupuk`
  ADD PRIMARY KEY (`id_pupuk`);

--
-- AUTO_INCREMENT untuk tabel yang dibuang
--

--
-- AUTO_INCREMENT untuk tabel `tbkeluar`
--
ALTER TABLE `tbkeluar`
  MODIFY `id_keluar` int(5) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
