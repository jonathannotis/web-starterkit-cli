from django.conf.urls import include
from django.urls import re_path, path
from django.contrib import admin

urlpatterns = [
    re_path(r'^', include('users.urls')),
    path('admin/', admin.site.urls),

]
