﻿namespace LivrariaOnline.Communication.Requests;

public class RequestUpdateLivroJson
{
    public string? Title { get; set; } = string.Empty;
    public string? Author { get; set; } = string.Empty;
    public string? Genre { get; set; } = string.Empty;
    public float? Price { get; set; }
    public int? Stock { get; set; }
}
