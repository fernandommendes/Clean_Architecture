using CleanArchMvc.Domain.Entities;
using FluentAssertions;

namespace CleanArchMvc.Domain.Test
{
    public class CategoryUnitTest1
    {
        [Fact(DisplayName = "Creat Category With Valid State")]
        public void CreatCategory_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Category(1,"Category Name");
            action.Should().NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreatCategory_NegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Category(-1, "Category Name");
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid Id value.");
        }

        [Fact]
        public void CreatCategory_ShortNameValue_DomainExceptionShortName()
        {
            Action action = () => new Category(1, "Ca");
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid name, too short, minimum 3 characteres.");
        }

        [Fact]
        public void CreatCategory_MissingNameValues_DomainExceptionRequiredName()
        {
            Action action = () => new Category(1, "");
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid name. Name is required.");
        }

        [Fact]
        public void CreatCategory_WithNullNameValue_DomainExceptionInvalidName()
        {
            Action action = () => new Category(1, "");
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }
    }
}