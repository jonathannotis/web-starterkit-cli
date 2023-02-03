from django.db import models


class User(models.Model):
    email = models.CharField(max_length=70, blank=False, default='')
    first_name = models.CharField(max_length=70, blank=False, default='')
    last_name = models.CharField(max_length=70, blank=False, default='')

    class Meta:
        db_table = 'user'
