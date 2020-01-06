from textwrap import dedent
import functools


# Add your solutions here

def count_odd(ns):
    return sum( 1 for n in ns if n % 2 != 0 )





# Test code below, stay away

class TestException(Exception):
    def __init__(self, message):
        self.message = message


def asserteq(expected, actual):
    if expected != actual:
        raise TestException(f"Expected {expected}, received {actual}")

class Tests:
    def read(self):
        line = self.__file.readline()
        while line.startswith('#'):
            line = self.__file.readline()
        return line.rstrip()

    def read_int(self):
        return int(self.read())

    def read_bool(self):
        return self.read() == 'true'

    def read_strings(self):
        n = self.read_int()
        return [ self.read() for _ in range(n) ]

    def run_tests(self):
        print(f"Testing {self.description}")
        with open(self.filename) as file:
            self.__file = file
            line = self.read()
            while line == 'testcase':
                self.perform_testcase()
                line = self.read()

class CountOddTests(Tests):
    @property
    def description(self):
        return 'count_odd'

    @property
    def filename(self):
        return 'count-odd.txt'

    def perform_testcase(self):
        ns = [ int(s) for s in self.read_strings() ]
        expected = self.read_int()

        try:
            asserteq(expected, count_odd(ns))
            print('PASS')
        except Exception as e:
            print(dedent(f'''
            FAILURE
            ns: {ns}
            Expected: {expected}
            Error: {e}
            ''').rstrip())



tests = [ CountOddTests() ]

for test in tests:
    test.run_tests()