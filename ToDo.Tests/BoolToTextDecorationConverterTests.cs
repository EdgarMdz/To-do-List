using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using To_do_List;
using Xamarin.Forms;

namespace ToDo.Tests
{
    public class BoolToTextDecorationConverterTests
    {
        [Fact]
        public void Convert_returns_strikethrough_when_item_is_completed()
        {
            //Arrange
            var convert = new BoolToTextDecorationConverter();

            //Act
            var res = convert.Convert(true, null, null, null);

            //Assert
            Assert.Equal(TextDecorations.Strikethrough, (TextDecorations)res);
        }

        [Fact]
        public void Convert_returns_none_when_item_is_not_completed()
        {
            //Arrange
            var convert = new BoolToTextDecorationConverter();

            //Act
            var res = convert.Convert(false, null, null, null);

            //Assert
            Assert.Equal(TextDecorations.None, (TextDecorations)res);
        }
    }
}
