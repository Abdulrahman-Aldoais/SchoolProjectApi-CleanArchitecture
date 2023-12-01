﻿using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Students.Querise.Respons;

namespace SchoolProject.Core.Features.Students.Querise.Models
{
    // Request "GetStudentListQuery" and Response List<Student>
    public class GetStudentListQuery : IRequest<Response<List<GetStudentListRespons>>>
    {
        //public ODataQueryOptions<GetStudentListRespons>? Options { get; }

        //public GetStudentListQuery(ODataQueryOptions<GetStudentListRespons> options)
        //{
        //    Options = options;
        //}
    }
}
