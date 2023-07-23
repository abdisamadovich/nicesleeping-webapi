﻿namespace NicesleepingShop.Domain.Exception.Files;

public class ImageNotFoundException :NotFoundException
{
    public ImageNotFoundException()
    {
        this.TitleMessage = "Image not found!";
    }
}
