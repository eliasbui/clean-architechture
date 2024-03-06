using Finbuckle.MultiTenant;
using FSH.Application.Common.Interfaces;
using FSH.Shared.Notifications;
using Microsoft.AspNetCore.SignalR;
using static FSH.Shared.Notifications.NotificationConstants;

namespace FSH.Infrastructure.Notifications;

public class NotificationSender : INotificationSender
{
    private readonly IHubContext<NotificationHub> _notificationHubContext;
    private readonly ITenantInfo _currentTenant;

    public NotificationSender(IHubContext<NotificationHub> notificationHubContext, ITenantInfo currentTenant)
    {
        (_notificationHubContext, _currentTenant) = (notificationHubContext, currentTenant);
    }

    public Task BroadcastAsync(INotificationMessage notification, CancellationToken cancellationToken)
    {
        return _notificationHubContext.Clients.All
            .SendAsync(NotificationFromServer, notification.GetType().FullName, notification, cancellationToken);
    }

    public Task BroadcastAsync(INotificationMessage notification, IEnumerable<string> excludedConnectionIds,
        CancellationToken cancellationToken)
    {
        return _notificationHubContext.Clients.AllExcept(excludedConnectionIds)
            .SendAsync(NotificationFromServer, notification.GetType().FullName, notification, cancellationToken);
    }

    public Task SendToAllAsync(INotificationMessage notification, CancellationToken cancellationToken)
    {
        return _notificationHubContext.Clients.Group($"GroupTenant-{_currentTenant.Id}")
            .SendAsync(NotificationFromServer, notification.GetType().FullName, notification, cancellationToken);
    }

    public Task SendToAllAsync(INotificationMessage notification, IEnumerable<string> excludedConnectionIds,
        CancellationToken cancellationToken)
    {
        return _notificationHubContext.Clients.GroupExcept($"GroupTenant-{_currentTenant.Id}", excludedConnectionIds)
            .SendAsync(NotificationFromServer, notification.GetType().FullName, notification, cancellationToken);
    }

    public Task SendToGroupAsync(INotificationMessage notification, string group,
        CancellationToken cancellationToken)
    {
        return _notificationHubContext.Clients.Group(group)
            .SendAsync(NotificationFromServer, notification.GetType().FullName, notification, cancellationToken);
    }

    public Task SendToGroupAsync(INotificationMessage notification, string group,
        IEnumerable<string> excludedConnectionIds, CancellationToken cancellationToken)
    {
        return _notificationHubContext.Clients.GroupExcept(group, excludedConnectionIds)
            .SendAsync(NotificationFromServer, notification.GetType().FullName, notification, cancellationToken);
    }

    public Task SendToGroupsAsync(INotificationMessage notification, IEnumerable<string> groupNames,
        CancellationToken cancellationToken)
    {
        return _notificationHubContext.Clients.Groups(groupNames)
            .SendAsync(NotificationFromServer, notification.GetType().FullName, notification, cancellationToken);
    }

    public Task SendToUserAsync(INotificationMessage notification, string userId,
        CancellationToken cancellationToken)
    {
        return _notificationHubContext.Clients.User(userId)
            .SendAsync(NotificationFromServer, notification.GetType().FullName, notification, cancellationToken);
    }

    public Task SendToUsersAsync(INotificationMessage notification, IEnumerable<string> userIds,
        CancellationToken cancellationToken)
    {
        return _notificationHubContext.Clients.Users(userIds)
            .SendAsync(NotificationFromServer, notification.GetType().FullName, notification, cancellationToken);
    }
}