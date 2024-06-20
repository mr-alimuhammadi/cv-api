using cv_api.DTOs;
using cv_api.Models;

namespace cv_api.Mappers;

public static class TestimonialMapper
{
    public static Testimonial ToTestimonial(this TestimonialPostDto testimonialPostDto, int id)
    {
        return new Testimonial
        (
            id,
            testimonialPostDto.UserId,
            testimonialPostDto.ClientName,
            testimonialPostDto.ClientJob,
            testimonialPostDto.ClientImage,
            testimonialPostDto.Comment
        );
    }
}