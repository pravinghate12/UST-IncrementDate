using IncrementDate.Services;

var validator = new DateValidator();
var calculator = new DateCalculator(validator);
var testRunner = new DateTestRunner(calculator);

testRunner.RunPositiveTests();
testRunner.RunNegativeTests();
