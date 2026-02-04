using EduCraft.Application.DTOs.Courses;
using EduCraft.Application.Helpers;
using EduCraft.Application.Mappers;
using EduCraft.Domain.Courses;
using EduCraft.Domain.Interfaces;

namespace EduCraft.Application.Services;

public class CourseService(ICourseRepository courseRepository)
{
    private readonly ICourseRepository _courseRepository = courseRepository;

    public async Task<ResponseResult<CourseDto>> CreateCourseAsync(CreateCourseDto dto)
    {
        //if (await _courseRepository.ExistsAsync(c => c.CourseCode == dto.CourseCode))
        //    return ResponseResult<CourseDto>.Conflict($"Course with code {dto.CourseCode} already exists");

        //var savedCourse = await _courseRepository.CreateAsync(new Course { CourseCode = dto.CourseCode, CourseName = dto.CourseName, Description = dto.Description });
        //return ResponseResult<CourseDto>.OK(CourseMapper.ToCourseDto(savedCourse));

        throw new NotImplementedException();
    }

    public async Task<ResponseResult<IEnumerable<CourseDto>>> GetAllCoursesAsync()
    {
        //var courses = await _courseRepository.GetAllAsync();
        //return ResponseResult<IEnumerable<CourseDto>>.OK(courses.Select(c => new CourseDto
        //{
        //    Id = c.Id,
        //    CourseCode = c.CourseCode,
        //    CourseName = c.CourseName,
        //    CreatedAt = c.CreatedAt,
        //    UpdatedAt = c.UpdatedAt,
        //    Description = c.Description,
        //}));

        throw new NotImplementedException();
    }
}
