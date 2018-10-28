using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContentController : MonoBehaviour
{
    [SerializeField]
    private Dictionary<CourseResourceType, bool> filters;
    [SerializeField]
    private Dictionary<string, bool> courses;

    private void Awake()
    {
        filters = new Dictionary<CourseResourceType, bool>();
        courses = new Dictionary<string, bool>();

        filters.Add(CourseResourceType.Assignment, false);
        filters.Add(CourseResourceType.Lecture, false);
        filters.Add(CourseResourceType.Notes, false);
        filters.Add(CourseResourceType.Other, false);    
        courses.Add("COMP2230", false);    
        courses.Add("ENGG2500", false);    
        courses.Add("SENG2260", false);    
        courses.Add("SENG3160", false);
    }

    // Start is called before the first frame update
    void Start()
    {
        var resources = gameObject.GetComponentsInChildren<CourseResource>();

        foreach (var resource in resources)
        {
            var buttons = resource.gameObject.GetComponentsInChildren<Button>();
            foreach (var button in buttons)
            {
                if (button.CompareTag("Video") && resource.video == null)
                {
                    button.gameObject.SetActive(false);
                }
            }
        }
    }

    public void ToggleFilter(string type)
    {
        CourseResourceType.TryParse(type, out CourseResourceType filter);
        filters[filter] = !filters[filter];
    }

    public void ToggleCourse(string course)
    {
        courses[course] = !courses[course];
    }

    // Update is called once per frame
    void Update()
    {
        bool allCourses = true;

        foreach (var course in courses)
        {
            if (course.Value)
            {
                allCourses = false;
                break;
            }
        }

        bool allFilters = true;

        foreach (var filter in filters)
        {
            if (filter.Value)
            {
                allFilters = false;
                break;
            }
        }

        var resources = gameObject.GetComponentsInChildren<CourseResource>(true);

        foreach (var resource in resources)
        {
            resource.gameObject.SetActive(
                (courses[resource.course] || allCourses) &&
                (filters[resource.type] || allFilters)
            );
        }
    }
}
