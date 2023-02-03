from django.apps import AppConfig

# https://stackoverflow.com/questions/67056517/django-3-2-exception-django-core-exceptions-improperlyconfigured
# absolute path

class UsersConfig(AppConfig):
    default_auto_field = 'django.db.models.BigAutoField'
    name = 'users'


