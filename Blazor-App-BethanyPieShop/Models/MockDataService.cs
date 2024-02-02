﻿using BethanysPieShopHRM.Shared.Domain;
using System.Diagnostics.Metrics;
using System.Reflection;

namespace BlazorBethanyPieShop.App.Models
{
	public class MockDataService
	{
		private static List<Employee>? _employees = default!;
		private static List<JobCategory> _jobCategories = default!;
		private static List<Country> _countries = default!;

		public static List<Employee> Employees
		{
			get
			{
				//we will use these in initialization of Employees
				_countries ??= InitializeMockCountries();

				_jobCategories ??= InitializeMockJobCategories();

				_employees ??= InitializeMockEmployees();

				return _employees;
			}
		}

		private static List<Employee> InitializeMockEmployees()
		{
			var e1 = new Employee
			{
				MaritalStatus = MaritalStatus.Single,
				City = "Brussels",
				Email = "bethany@bethanyspieshop.com",
				EmployeeId = 1,
				FirstName = "Bethany",
				LastName = "Smith",
				Gender = Gender.Female,
				PhoneNumber = "324777888773",
				Smoker = false,
				Street = "Grote Markt 1",
				Zip = "1000",
				JobCategory = _jobCategories[2],
				JobCategoryId = _jobCategories[2].JobCategoryId,
				Comment = "Lorem Ipsum",
				Country = _countries[0],
				CountryId = _countries[0].CountryId
			};

			var e2 = new Employee
			{
				MaritalStatus = MaritalStatus.Married,
				City = "Antwerp",
				Email = "gill@bethanyspieshop.com",
				EmployeeId = 2,
				FirstName = "Gill",
				LastName = "Cleeren",
				Gender = Gender.Male,
				PhoneNumber = "33999909923",
				Smoker = false,
				Street = "New Street",
				Zip = "2000",
				JobCategory = _jobCategories[1],
				JobCategoryId = _jobCategories[1].JobCategoryId,
				Comment = "Lorem Ipsum",
				Country = _countries[1],
				CountryId = _countries[1].CountryId
			};

			var e3 = new Employee
			{
				MaritalStatus = MaritalStatus.Married,
				City = "Antwerp",
				Email = "jane@bethanyspieshop.com",
				EmployeeId = 2,
				FirstName = "Jane",
				LastName = String.Empty,
				Gender = Gender.Female,
				PhoneNumber = "33999909923",
				Smoker = false,
				Street = "New Street",
				Zip = "2000",
				JobCategory = _jobCategories[1],
				JobCategoryId = _jobCategories[1].JobCategoryId,
				Comment = "Lorem Ipsum",
				Country = _countries[1],
				CountryId = _countries[1].CountryId
			};

			return new List<Employee>() { e1, e2, e3 };
		}

		private static List<JobCategory> InitializeMockJobCategories()
		{
			return new List<JobCategory>()
			{
				new JobCategory{JobCategoryId = 1, JobCategoryName = "Pie research"},
				new JobCategory{JobCategoryId = 2, JobCategoryName = "Sales"},
				new JobCategory{JobCategoryId = 3, JobCategoryName = "Management"},
				new JobCategory{JobCategoryId = 4, JobCategoryName = "Store staff"},
				new JobCategory{JobCategoryId = 5, JobCategoryName = "Finance"},
				new JobCategory{JobCategoryId = 6, JobCategoryName = "QA"},
				new JobCategory{JobCategoryId = 7, JobCategoryName = "IT"},
				new JobCategory{JobCategoryId = 8, JobCategoryName = "Cleaning"},
				new JobCategory{JobCategoryId = 9, JobCategoryName = "Bakery"},
				new JobCategory{JobCategoryId = 9, JobCategoryName = "Bakery"}
			};
		}

		private static List<Country> InitializeMockCountries()
		{
			return new List<Country>
				{
				new Country {CountryId = 1, Name = "Belgium"},
				new Country {CountryId = 2, Name = "Netherlands"},
				new Country {CountryId = 3, Name = "USA"},
				new Country {CountryId = 4, Name = "Japan"},
				new Country {CountryId = 5, Name = "China"},
				new Country {CountryId = 6, Name = "UK"},
				new Country {CountryId = 7, Name = "France"},
				new Country {CountryId = 8, Name = "Brazil"}
			};
		}
	}
}

