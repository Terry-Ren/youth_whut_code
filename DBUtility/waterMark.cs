using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace AUTO.Utility
{
    public class waterMarker
    {
        /// <summary>
        /// 文字水印
        /// </summary>
        /// <param name="ImgFile">原图文件地址</param>
        /// <param name="TextFont">水印文字</param>
        /// <param name="sImgPath">文字水印图片保存地址</param>
        /// <param name="hScale">高度位置</param>
        /// <param name="widthFont">文字块在图片中所占宽度比例</param>
        /// <param name="Alpha">文字透明度 其数值的范围在0到255</param>
        public bool waterMark(string ImgFile  , string TextFont , string sImgPath  , float hScale  , float widthFont  , int Alpha)
        {
            try
                {
                    FileStream fs = new FileStream(ImgFile, FileMode.Open);
                    BinaryReader br = new BinaryReader(fs);
                    byte[] bytes = br.ReadBytes((int)fs.Length);
                    br.Close();
                    fs.Close();
                    MemoryStream ms = new MemoryStream(bytes);
                    System.Drawing.Image imgPhoto = System.Drawing.Image.FromStream(ms);
                    //System.Drawing.Image imgPhoto = System.Drawing.Image.FromFile(ImgFile);
                    int imgPhotoWidth = imgPhoto.Width;
                    int imgPhotoHeight = imgPhoto.Height;
                    Bitmap bmPhoto = new Bitmap(imgPhotoWidth, imgPhotoHeight, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                    bmPhoto.SetResolution(72, 72);
                    Graphics gbmPhoto = Graphics.FromImage(bmPhoto);
                    gbmPhoto.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
                    gbmPhoto.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                    gbmPhoto.DrawImage(
                      imgPhoto
                     , new Rectangle(0, 0, imgPhotoWidth, imgPhotoHeight)
                     , 0
                     , 0
                     , imgPhotoWidth
                     , imgPhotoHeight
                     , GraphicsUnit.Pixel
                     );
                    //建立字体大小的数组,循环找出适合图片的水印字体
                    //int[] sizes = new int[] { 1000, 800, 700, 650, 600, 560, 540, 500, 450, 400, 380, 360, 340, 320, 300, 280, 260, 240, 220, 200, 180, 160, 140, 120, 100, 80, 72, 64, 48, 32, 28, 26, 24, 20, 28, 16, 14, 12, 10, 8, 6, 4, 2 };
                    int[] sizes = new int[] { 28, 26, 24, 20, 16, 14, 12 };
                    System.Drawing.Font crFont = null;
                    System.Drawing.SizeF crSize = new SizeF();
                    for (int i = 0; i < 7; i++)
                    {
                        crFont = new Font("微软雅黑", sizes[i], FontStyle.Bold);
                        crSize = gbmPhoto.MeasureString(TextFont, crFont);
                        if ((ushort)crSize.Width < (ushort)imgPhotoWidth * widthFont)
                            break;
                    }
                    //设置水印字体的位置
                    //int yPixlesFromBottom = (int)(imgPhotoHeight * hScale);
                    //float yPosFromBottom = ((imgPhotoHeight - yPixlesFromBottom) - (crSize.Height / 2));
                    //float xCenterOfImg = (imgPhotoWidth * 1 / 2);
                    float yPosFromBottom = imgPhotoHeight * 0.85f;
                    float xCenterOfImg = imgPhotoWidth * 0.8f;
                    //if (xCenterOfImg<crSize.Height)
                    // xCenterOfImg = (imgPhotoWidth * (1 - (crSize.Height)/ imgPhotoWidth));
                    System.Drawing.StringFormat StrFormat = new System.Drawing.StringFormat();
                    StrFormat.Alignment = System.Drawing.StringAlignment.Center;
                    //
                    System.Drawing.SolidBrush semiTransBrush2 = new System.Drawing.SolidBrush(Color.FromArgb(Alpha, 0, 0, 0));
                    gbmPhoto.DrawString(
                      TextFont
                     , crFont
                     , semiTransBrush2
                     , new System.Drawing.PointF(xCenterOfImg + 1, yPosFromBottom + 1)
                     , StrFormat
                     );
                    System.Drawing.SolidBrush semiTransBrush = new System.Drawing.SolidBrush(Color.FromArgb(Alpha, 255, 255, 255));
                    //gbmPhoto.FillRectangle(semiTransBrush2, new RectangleF(new PointF(xCenterOfImg - crSize.Width / 2, yPosFromBottom - 4), crSize));
                    gbmPhoto.DrawString(
                      TextFont
                     , crFont
                     , semiTransBrush
                     , new System.Drawing.PointF(xCenterOfImg, yPosFromBottom)
                     , StrFormat
                     );
                    bmPhoto.Save(sImgPath, System.Drawing.Imaging.ImageFormat.Jpeg);
                    gbmPhoto.Dispose();
                    imgPhoto.Dispose();
                    bmPhoto.Dispose();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            
        
    }
}
