using System.Collections.Generic;

public class BaoCaoDoanhThuBAL
{
    private BaoCaoDoanhThuDAL dal = new BaoCaoDoanhThuDAL();

    public List<BaoCaoDoanhThuDTO> LayDanhSachBaoCao()
    {
        return dal.LayDanhSachBaoCao();
    }
}
