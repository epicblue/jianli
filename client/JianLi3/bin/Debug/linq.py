import clr
clr.AddReference('System.Core') 

import System
from System.Linq import Enumerable
from System import Func 


# Pythonic wrappers around some common linq functions
def Count(col, fun = lambda x: True):
    return Enumerable.Count[object](col, Func[object, bool](fun))
 

def OrderBy(col, fun):
    return Enumerable.OrderBy[object, object](col, Func[object, object](fun))     

def OrderByDesc(col, fun):
    return Enumerable.OrderByDescending[object, object](col, Func[object, object](fun)) 

def Select(col, fun):
    return Enumerable.Select[object, object](col, Func[object, object](fun)) 

def Single(col, fun):

    return Enumerable.Single[object](col, Func[object, bool](fun))

def Where(col, fun):
    return Enumerable.Where[object](col, Func[object, bool](fun))


# Save all Pythonic wrappers into dict
this_module = __import__(__name__)
linqs = {}
for name in dir(this_module):
    if name.startswith('__') or name in ('this_module', 'linqs'):
        continue
    linqs[name] = getattr(this_module, name)


def is_enumerable(obj):
    ienum_object = System.Collections.Generic.IEnumerable[object]
    return isinstance(obj, ienum_object)


class LinqAdapter(object):
    def __init__(self, col):
        self.col = col 

    def __iter__(self):
        return iter(self.col)
        
    def __str__(self):
        return '[%s]' % ', '.join( (str(v) for v in self) )         

    def __repr__(self):
        return str(self)         

    def __getattr__(self, attr):
        def decorator(*arg, **kws):
            result = linqs[attr](self.col, *arg, **kws)
            if is_enumerable(result):
                return LinqAdapter(result)
            else:
                return result
        return decorator

 
class IEnumerableAdapter(System.Collections.Generic.IEnumerable[object],
    System.Collections.Generic.IEnumerator[object]):
    def __init__(self, iteration):
        self.iter = iter(iteration)
        self.element = None
          
    def GetEnumerator(self):
        return self
   
    def get_Current(self):
        return self.element
          
    def MoveNext(self):
        try:
            self.element = self.iter.next()
            return True
        except StopIteration:
            return False
      
    def Dispose(self):
        pass


def From(col):
    if not is_enumerable(col):
        col = IEnumerableAdapter(col)
    return LinqAdapter(col)