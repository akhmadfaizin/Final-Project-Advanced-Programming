using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectDao.Entity
{
    class EntData
    {
        // Entitas tb_tarif
        private int e_id_tarif;
        private int e_lama_hari;
        private string e_kota_pengiriman;
        private string e_kota_tujuan;
        private char e_tipe_barang;
        private int e_ongkos;

        // Entitas tb_pengirim
        private string e_id_pengirim;
        private string e_nama_pengirim;
        private char e_jk_pengirim;
        private string e_kode_pos_pengirim;
        private string e_no_hub_pengirim;
        private string e_alamat_pengirim;
        private string e_rt_pengirim;
        private string e_rw_pengirim;
        private string e_desa_pengirim;
        private string e_kec_pengirim;
        private int id_kab_pengirim;
        private int id_prov_pengirim;

        // Entitas tb_penerima
        private string e_id_penerima;
        private string e_nama_penerima;
        private char e_jk_penerima;
        private string e_kode_pos_penerima;
        private string e_no_hub_penerima;
        private string e_alamat_penerima;
        private string e_rt_penerima;
        private string e_rw_penerima;
        private string e_desa_penerima;
        private string e_kec_penerima;
        private int id_kab_penerima;
        private int id_prov_penerima;

        // Entitas tb_transaksi
        private int e_id_transaksi;
        private string e_tgl_transaksi;
        private int e_berat;
        private string e_id_pegawai;

        // Entitas Untuk Cek Duplikat
        private Boolean e_duplikatpengirim;
        private Boolean e_duplikatpenerima;


        /////// FUNGSI GET SET tb_tarif
        public int getIdTarif()
        {
            return e_id_tarif;
        }

        public void setIdTarif(int a)
        {
            e_id_tarif = a;
        }

        public int getLamaHari()
        {
            return e_lama_hari;
        }

        public void setLamaHari(int a)
        {
            e_lama_hari = a;
        }

        public string getKotaPengiriman()
        {
            return e_kota_pengiriman;
        }

        public void setKotaPengiriman(string a)
        {
            e_kota_pengiriman = a;
        }

        public string getKotaTujuan()
        {
            return e_kota_tujuan;
        }

        public void setKotaTujuan(string a)
        {
            e_kota_tujuan = a;
        }

        public char getTipeBarang()
        {
            return e_tipe_barang;
        }

        public void setTipeBarang(char a)
        {
            e_tipe_barang = a;
        }

        public int getOngkos()
        {
            return e_ongkos;
        }

        public void setOngkos(int a)
        {
            e_ongkos = a;
        }
        // END OF FUNGSI GET SET tb_tarif


        /////// FUNGSI GET SET tb_pengirim
        public string getIdPengirim()
        {
            return e_id_pengirim;
        }

        public void setIdPengirim(string a)
        {
            e_id_pengirim = a;
        }

        public string getNamaPengirim()
        {
            return e_nama_pengirim;
        }

        public void setNamaPengirim(string a)
        {
            e_nama_pengirim = a;
        }

        public char getJkPengirim()
        {
            return e_jk_pengirim;
        }

        public void setJkPengirim(char a)
        {
            e_jk_pengirim = a;
        }

        public string getKodePosPengirim()
        {
            return e_kode_pos_pengirim;
        }

        public void setKodePosPengirim(string a)
        {
            e_kode_pos_pengirim = a;
        }

        public string getNoHubPengirim()
        {
            return e_no_hub_pengirim;
        }

        public void setNoHubPengirim(string a)
        {
            e_no_hub_pengirim = a;
        }

        public string getAlamatPengirim()
        {
            return e_alamat_pengirim;
        }

        public void setAlamatPengirim(string a)
        {
            e_alamat_pengirim = a;
        }

        public string getRtPengirim()
        {
            return e_rt_pengirim;
        }

        public void setRtPengirim(string a)
        {
            e_rt_pengirim = a;
        }

        public string getRwPengirim()
        {
            return e_rw_pengirim;
        }

        public void setRwPengirim(string a)
        {
            e_rw_pengirim = a;
        }

        public string getDesaPengirim()
        {
            return e_desa_pengirim;
        }

        public void setDesaPengirim(string a)
        {
            e_desa_pengirim = a;
        }

        public string getKecPengirim()
        {
            return e_kec_pengirim;
        }

        public void setKecPengirim(string a)
        {
            e_kec_pengirim = a;
        }

        public int getId_KabPengirim()
        {
            return id_kab_pengirim;
        }

        public void setId_KabPengirim(int a)
        {
            id_kab_pengirim = a;
        }

        public int getId_ProvPengirim()
        {
            return id_prov_pengirim;
        }

        public void setId_ProvPengirim(int a)
        {
            id_prov_pengirim = a;
        }
        // END OF FUNGSI GET SET tb_pengirim


        /////// FUNGSI GET SET tb_penerima
        public string getIdPenerima()
        {
            return e_id_penerima;
        }

        public void setIdPenerima(string a)
        {
            e_id_penerima = a;
        }

        public string getNamaPenerima()
        {
            return e_nama_penerima;
        }

        public void setNamaPenerima(string a)
        {
            e_nama_penerima = a;
        }

        public char getJkPenerima()
        {
            return e_jk_penerima;
        }

        public void setJkPenerima(char a)
        {
            e_jk_penerima = a;
        }

        public string getKodePosPenerima()
        {
            return e_kode_pos_penerima;
        }

        public void setKodePosPenerima(string a)
        {
            e_kode_pos_penerima = a;
        }

        public string getNoHubPenerima()
        {
            return e_no_hub_penerima;
        }

        public void setNoHubPenerima(string a)
        {
            e_no_hub_penerima = a;
        }

        public string getAlamatPenerima()
        {
            return e_alamat_penerima;
        }

        public void setAlamatPenerima(string a)
        {
            e_alamat_penerima = a;
        }

        public string getRtPenerima()
        {
            return e_rt_penerima;
        }

        public void setRtPenerima(string a)
        {
            e_rt_penerima = a;
        }

        public string getRwPenerima()
        {
            return e_rw_penerima;
        }

        public void setRwPenerima(string a)
        {
            e_rw_penerima = a;
        }

        public string getDesaPenerima()
        {
            return e_desa_penerima;
        }

        public void setDesaPenerima(string a)
        {
            e_desa_penerima = a;
        }

        public string getKecPenerima()
        {
            return e_kec_penerima;
        }

        public void setKecPenerima(string a)
        {
            e_kec_penerima = a;
        }

        public int getId_KabPenerima()
        {
            return id_kab_penerima;
        }

        public void setId_KabPenerima(int a)
        {
            id_kab_penerima = a;
        }

        public int getId_ProvPenerima()
        {
            return id_prov_penerima;
        }

        public void setId_ProvPenerima(int a)
        {
            id_prov_penerima = a;
        }
        // END OF FUNGSI GET SET tb_penerima


        /////// FUNGSI GET SET tb_transaksi
        public int getIdTransaksi()
        {
            return e_id_transaksi;
        }

        public void setIdTransaksi(int a)
        {
            e_id_transaksi = a;
        }

        public string getTglTransaksi()
        {
            return e_tgl_transaksi;
        }

        public void setTglTransaksi(string a)
        {
            e_tgl_transaksi = a;

        }

        public int getBerat()
        {
            return e_berat;
        }

        public void setBerat(int a)
        {
            e_berat = a;
        }

        public string getIdPegawai()
        {
            return e_id_pegawai;
        }

        public void setIdPegawai(string a)
        {
            e_id_pegawai = a;

        }
        // END OF FUNGSI GET SET tb_transaksi


        //Fungsi GET SET status duplikat pengirim
        public Boolean getStatusDuplikatPengirim()
        {
            return e_duplikatpengirim;
        }

        public void setStatusDuplikatPengirim(Boolean b)
        {
            e_duplikatpengirim = b;

        }

        //Fungsi GET SET status duplikat penerima
        public Boolean getStatusDuplikatPenerima()
        {
            return e_duplikatpenerima;
        }

        public void setStatusDuplikatPenerima(Boolean b)
        {
            e_duplikatpenerima = b;
        }
    }
}
