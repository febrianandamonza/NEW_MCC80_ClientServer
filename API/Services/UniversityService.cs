using API.Contracts;
using API.DTOs.Universities;
using API.Models;

namespace API.Services;

public class UniversityService
{
    private readonly IUniversityRepository _universityRepository;

    public UniversityService(IUniversityRepository universityRepository)
    {
        _universityRepository = universityRepository;
    }

    public IEnumerable<UniversityDto> GetALl()
    {
        var universities = _universityRepository.GetAll();
        if (!universities.Any())
        {
            return Enumerable.Empty<UniversityDto>();
        }

        var universityDtos = new List<UniversityDto>();
        foreach (var university in universities)
        {
            universityDtos.Add((UniversityDto)university);
        }

        return universityDtos;
    }

    public UniversityDto? GetByGuid(Guid guid)
    {
        var university = _universityRepository.GetByGuid(guid);
        if (university is null)
        {
            return null;
        }

        return ((UniversityDto)university);
    }

    public UniversityDto? Create(NewUniversityDto newUniversityDto)
    {
        var university = _universityRepository.Create(newUniversityDto);
        if (university is null)
        {
            return null;
        }

        return ((UniversityDto)university);
    }

    public int Update(UniversityDto universityDto)
    {
        var university = _universityRepository.GetByGuid(universityDto.Guid);
        if (university is null)
        {
            return -1;
        }

        University toUpdate = universityDto;
        toUpdate.CreatedDate = university.CreatedDate;
        var result = _universityRepository.Update(toUpdate);
        return result ? 1 
            : 0;
    }

    public int Delete(Guid guid)
    {
        var university = _universityRepository.GetByGuid(guid);
        if (university is null)
        {
            return -1;
        }

        var result = _universityRepository.Delete(university);
        return result ? 1
            : 0;
    }
}